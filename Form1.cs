using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imgSummator
{
    public partial class MainForm : Form
    {
        #region Переменные
        string defPath = "";
        string defExt = "";
        Bitmap MainBitMap = null;
        Bitmap DiffBitMap = null;
        uint[,] MainColors;
        uint[,] DiffColors;
        uint[][,] SecColors;
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Добавляем главную картинку от которой будут вестись расчёты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMainImageBttn_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Images | *.bmp; *.png; *.jpg";
            openFileDialog.Multiselect = false;
            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                defPath = openFileDialog.FileName.Replace(openFileDialog.SafeFileName, "");
                defExt = openFileDialog.SafeFileName.Split('.')[1];
                ListViewItem delitem = null;
                int KeyIndx = ImgsListView.Items.IndexOfKey("Main");
                // Удалим предыдущий Main если он существует
                if (KeyIndx != -1)
                {
                    delitem = ImgsListView.Items[KeyIndx];
                }
                if (delitem != null)
                {
                    //imageList.Images["Main"].Dispose();
                    ImgsListView.Items.Remove(delitem);
                }
                //imageList.Images.RemoveByKey("Main");
                imageList.Images.Add("Main", Image.FromFile(openFileDialog.FileName));
                ListViewItem listViewItem = new ListViewItem(new string[] { "", openFileDialog.FileName, "Main" });
                listViewItem.Text = "Main";
                listViewItem.ImageIndex = imageList.Images.Count - 1;
                listViewItem.Name = "Main";
                //listViewItem.ImageIndex = 0;
                ImgsListView.Items.Add(listViewItem);
                // Установим главный битмап и перепроверим на включение кнопок
                MainBitMap = new Bitmap(Image.FromFile(openFileDialog.FileName));
                MainColors = img2Array(MainBitMap);
                GC.Collect();
                BttsCheker();
            }
        }

        /// <summary>
        /// Прогрузим на главном экране даблклик по списку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImgsListView_ItemActivate(object sender, EventArgs e)
        {
            //BigImaxPictureBox.Image = Image.FromFile((sender as ListView).SelectedItems[0].SubItems[1].Text);
            BigImaxPictureBox.ImageLocation = (sender as ListView).SelectedItems[0].SubItems[1].Text;
        }

        /// <summary>
        /// Добавляем вторичные картинки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSecondImageBttn_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Images | *.bmp; *.png; *.jpg";
            openFileDialog.Multiselect = true;
            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                ListViewItem delitem = null;
                int KeyIndx = ImgsListView.Items.IndexOfKey("Second");
                // Удаляем предыдущие
                while (KeyIndx != -1)
                {
                    if (KeyIndx != -1)
                    {
                        delitem = ImgsListView.Items[KeyIndx];
                    }
                    if (delitem != null)
                    {
                        ImgsListView.Items.Remove(delitem);
                    }
                    KeyIndx = ImgsListView.Items.IndexOfKey("Second");
                }
                // Добавляем новые
                foreach (string name in openFileDialog.FileNames)
                {
                    imageList.Images.Add("Second", Image.FromFile(name));
                    ListViewItem listViewItem = new ListViewItem(new string[] { "", name, "Second" });
                    listViewItem.Text = "Second";
                    listViewItem.ImageIndex = imageList.Images.Count - 1;
                    listViewItem.Name = "Second";
                    //listViewItem.ImageIndex = 0;
                    ImgsListView.Items.Add(listViewItem);
                    GC.Collect();
                }
            }
            CreateDifferenceBttn.Enabled = true;
            BttsCheker();
        }

        /// <summary>
        /// Изменим размер основной картинки что бы были скролбары
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imagepanel_Resize(object sender, EventArgs e)
        {
            BigImaxPictureBox.Size = imagepanel.ClientSize;
        }

        /// <summary>
        /// Создадим конечный файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateEndBttn_Click(object sender, EventArgs e)
        {
            Bitmap MainBitMap = null;
            Bitmap DiffBitMap = null;
            int ItemsCount = ImgsListView.Items.Count;
            for (int i = 0; i < ItemsCount; i++)
            {
                ListViewItem lvi = ImgsListView.Items[i];
                if (lvi.Text.Equals("Main"))
                {
                    MainBitMap = new Bitmap(Image.FromFile(lvi.SubItems[1].Text));
                    //img2Array(MainBitMap,out MainColors);
                }
                if (lvi.Text.Equals("Diff"))
                {
                    DiffBitMap = new Bitmap(Image.FromFile(lvi.SubItems[1].Text));
                }
            }
            if (DiffBitMap == null || MainBitMap == null)
            {
                MessageBox.Show("Не найден основной или разностный файл!!");
            }
            else
            {
                int height = DiffBitMap.Height;
                int width = DiffBitMap.Width;
                MainColors = img2Array(MainBitMap);
                DiffColors = img2Array(DiffBitMap);
                for (int y = 0; y < height; y++)
                {
                    Parallel.For(0, width, x =>
                   {
                       if (DiffColors[x, y] != 0)
                       {
                           MainColors[x, y] = DiffColors[x, y];
                       }
                       if (BWchkbx.Checked && DiffColors[x, y] == 0)
                       {
                           double R = ((MainColors[x, y] & 0x00FF0000) >> 16);
                           double G = ((MainColors[x, y] & 0x0000FF00) >> 8);
                           double B = ((MainColors[x, y] & 0x000000FF));
                           uint med = (uint)(R * 0.299 + G * 0.587 + B * 0.114);
                           if (med > 255) med = 255;
                           MainColors[x, y] = ((uint)((255 << 24) + (med << 16) + (med << 8) + med));
                       }
                   });
                }
                string EndFullPath = defPath + "end." + defExt;

                MainBitMap = Array2img(MainColors, MainBitMap);
                MainBitMap.Save(EndFullPath);
                if (BigImaxPictureBox.ImageLocation == EndFullPath) BigImaxPictureBox.ImageLocation = EndFullPath;

                ListViewItem delitem = null;
                int KeyIndx = ImgsListView.Items.IndexOfKey("End");
                if (KeyIndx != -1)
                {
                    delitem = ImgsListView.Items[KeyIndx];
                }
                if (delitem != null)
                {
                    //imageList.Images["End"].Dispose();
                    ImgsListView.Items.Remove(delitem);
                }
                // imageList.Images.RemoveByKey("End");
                imageList.Images.Add("End", Image.FromFile(EndFullPath));
                ListViewItem listViewItem = new ListViewItem(new string[] { "", EndFullPath, "End" });
                listViewItem.Text = "End";
                listViewItem.ImageIndex = imageList.Images.Count - 1;
                listViewItem.Name = "End";
                //listViewItem.ImageIndex = 0;
                ImgsListView.Items.Add(listViewItem);
                ItemsCount = ImgsListView.Items.Count;
                for (int i = 0; i < ItemsCount; i++)
                {
                    ListViewItem lvi = ImgsListView.Items[i];
                    if (lvi.Text.Equals("End"))
                    {
                        BigImaxPictureBox.ImageLocation = lvi.SubItems[1].Text;
                    }
                }
            }
            BttsCheker();
        }

        /// <summary>
        /// Указать разностное изображение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDiffBttn_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Images | *.bmp; *.png; *.jpg";
            openFileDialog.Multiselect = false;
            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                defPath = openFileDialog.FileName.Replace(openFileDialog.SafeFileName, "");
                defExt = openFileDialog.SafeFileName.Split('.')[1];
                ListViewItem delitem = null;
                int KeyIndx = ImgsListView.Items.IndexOfKey("Diff");
                if (KeyIndx != -1)
                {
                    delitem = ImgsListView.Items[KeyIndx];
                }
                if (delitem != null)
                {
                    //imageList.Images["Diff"].Dispose();
                    ImgsListView.Items.Remove(delitem);
                }
                //imageList.Images.RemoveByKey("Diff");
                imageList.Images.Add("Diff", Image.FromFile(openFileDialog.FileName));
                ListViewItem listViewItem = new ListViewItem(new string[] { "", openFileDialog.FileName, "Diff" });
                listViewItem.Text = "Diff";
                listViewItem.ImageIndex = imageList.Images.Count - 1;
                listViewItem.Name = "Diff";
                //listViewItem.ImageIndex = 0;
                ImgsListView.Items.Add(listViewItem);
            }
            DiffBitMap = new Bitmap(Image.FromFile(openFileDialog.FileName));
            DiffColors = img2Array(DiffBitMap);
            BttsCheker();
        }

        /// <summary>
        /// Проверочка на включение кнопок
        /// </summary>
        private void BttsCheker()
        {
            if (MainBitMap != null && DiffBitMap != null)
            {
                CreateEndBttn.Enabled = true;
            }
            else
            {
                CreateEndBttn.Enabled = false;
            }
        }

        private uint[,] img2Array(Bitmap bitmap)
        {
            int height = bitmap.Height;
            int width = bitmap.Width;
            uint[,] colors = new uint[width, height];

            uint[,] res = new uint[height, width];
            BitmapData bd = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly,
                PixelFormat.Format32bppRgb);
            int byteCount = bd.Stride * (height);
            int[] bytes = new int[byteCount / 4];
            Marshal.Copy(bd.Scan0, bytes, 0, byteCount / 4);
            bitmap.UnlockBits(bd);


            int nxt = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    colors[x, y] = (uint)bytes[nxt];
                    nxt++;
                }
            }
            return colors;
        }

        private Bitmap Array2img(uint[,] colors, Bitmap origBMP)
        {
            Bitmap bitmap = new Bitmap(origBMP);
            using (Graphics gr = Graphics.FromImage(bitmap))
            {
                gr.Clear(Color.FromArgb(0, 0, 0, 0));
            }
            int height = bitmap.Height;
            int width = bitmap.Width;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bitmap.SetPixel(x, y, Color.FromArgb((int)colors[x, y]));
                }
            }
            return bitmap;
        }

        /// <summary>
        /// Расчитаем разничную картинку от основной
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateDifferenceBttn_Click(object sender, EventArgs e)
        {
            progressBar.Minimum = 0;
            progressBar.Value = 0;
            int ItemsCount = ImgsListView.Items.Count;
            int secCount = 0;
            for (int i = 0; i < ItemsCount; i++)
            {
                ListViewItem lvi = ImgsListView.Items[i];
                if (lvi.Text.Equals("Second"))
                {
                    secCount++;
                }
            }
            progressBar.Maximum = secCount;
            progressBar.Step = 1;
            SecColors = new uint[secCount][,];
            secCount = 0;
            // Найдём основную картинку и перекинем вторичные

            for (int i = 0; i < ItemsCount; i++)
            {
                ListViewItem lvi = ImgsListView.Items[i];
                if (lvi.Text.Equals("Main"))
                {
                    MainBitMap = new Bitmap(Image.FromFile(lvi.SubItems[1].Text));
                    MainColors = img2Array(MainBitMap);
                    break;
                }
            }
            int height = MainBitMap.Height;
            int width = MainBitMap.Width;
            DiffColors = new uint[width, height];
            uint[][,] totalArr = new uint[4][,];// [ARGB][x,y]
            totalArr[0] = new uint[width, height];//A значение
            totalArr[1] = new uint[width, height];//R значение
            totalArr[2] = new uint[width, height];//G значение
            totalArr[3] = new uint[width, height];//B значение
            uint[,] cnt = new uint[width, height]; //счёт операций


            // обнулим totalArr и счётчик
            for (int y = 0; y < height; y++)
            {
                Parallel.For(0, width, x =>
                {
                    for (int RGB = 0; RGB < 4; RGB++)
                    {
                        totalArr[RGB][x, y] = 0;
                        totalArr[RGB][x, y] = 0;
                    }
                    cnt[x, y] = 0;
                });
            }

            for (int i = 0; i < ItemsCount; i++)
            {
                ListViewItem lvi = ImgsListView.Items[i];
                if (lvi.Text.Equals("Second"))
                {
                    progressBar.PerformStep();
                    DiffColors = img2Array(new Bitmap(Image.FromFile(lvi.SubItems[1].Text)));
                    Parallel.For(0, height, y =>
                     {
                         for (int x = 0; x < width; x++)
                         {
                             if (MainColors[x, y] != DiffColors[x, y])
                             {
                                 cnt[x, y]++;
                                 //A
                                 totalArr[0][x, y] += 255;
                                 //R
                                 totalArr[1][x, y] += ((DiffColors[x, y] & 0x00FF0000) >> 16);
                                 //G
                                 totalArr[2][x, y] += ((DiffColors[x, y] & 0x0000FF00) >> 8);
                                 //B
                                 totalArr[3][x, y] += ((DiffColors[x, y] & 0x000000FF));
                             }
                         }
                     });
                    DiffColors = null;
                    Application.DoEvents();
                    GC.Collect();
                }
                lvi = null;
            }
            

            DiffColors = new uint[width, height];
            for (int y = 0; y < height; y++)
            {
                Parallel.For(0, width, x =>
                {
                    /*if (totalArr[0][x, y] == 255)
                    {*/
                    uint res = 0;
                    uint div = cnt[x, y];
                    if (div == 0) div = 1;
                    res += ((totalArr[0][x, y]) << 24);
                    res += ((totalArr[1][x, y]) / div) << 16;
                    res += ((totalArr[2][x, y]) / div) << 8;
                    res += ((totalArr[3][x, y]) / div);
                    DiffColors[x, y] = res;
                    // }
                });
            }
            DiffBitMap = Array2img(DiffColors, MainBitMap);
            string DifFullPath = defPath + "diff." + defExt;
            DiffBitMap.Save(DifFullPath);
            if (BigImaxPictureBox.ImageLocation == DifFullPath) BigImaxPictureBox.ImageLocation = DifFullPath;
            DiffColors = null;
            progressBar.Value = 0;

            ListViewItem delitem = null;
            int KeyIndx = ImgsListView.Items.IndexOfKey("Diff");
            if (KeyIndx != -1)
            {
                delitem = ImgsListView.Items[KeyIndx];
            }
            if (delitem != null)
            {
                // imageList.Images["Diff"].Dispose();
                ImgsListView.Items.Remove(delitem);
            }
            //imageList.Images.RemoveByKey("Diff");
            imageList.Images.Add("Diff", Image.FromFile(DifFullPath));
            ListViewItem listViewItem = new ListViewItem(new string[] { "", DifFullPath, "Diff" });
            listViewItem.Text = "Diff";
            listViewItem.ImageIndex = imageList.Images.Count - 1;
            listViewItem.Name = "Diff";
            //listViewItem.ImageIndex = 0;
            ImgsListView.Items.Add(listViewItem);
            ItemsCount = ImgsListView.Items.Count;
            for (int i = 0; i < ItemsCount; i++)
            {
                ListViewItem lvi = ImgsListView.Items[i];
                if (lvi.Text.Equals("Diff"))
                {
                    BigImaxPictureBox.ImageLocation = lvi.SubItems[1].Text;
                }
            }
            BttsCheker();
        }
    }
}
