using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bitmapImage;
        Color[,] ImageArray = new Color[320, 240];

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

        //   openFileDialog1.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyPictures);
            openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Title = "Image Browser";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    Image newImage = Image.FromStream(myStream);
                    bitmapImage = new Bitmap(newImage, 320, 240);
                    picImage.Image = bitmapImage;
                    myStream.Close();
                }

                SetArrayFromBitmap();
            }
        }
        private void SetBitmapFromArray()
        {
            for (int row = 0; row < 320; row++)
                for (int col = 0; col < 240; col++)
                {
                    bitmapImage.SetPixel(row, col, ImageArray[row, col]);
                }
        }

        private void SetArrayFromBitmap()
        {
            for (int row = 0; row < 320; row++)
                for (int col = 0; col < 240; col++)
                {
                    ImageArray[row, col] = bitmapImage.GetPixel(row, col);
                }
        }

        
        private void btnTransform_Click(object sender, EventArgs e)
        {
            if (bitmapImage == null)
                return;

            // Process the array data here!!!

            byte Green;

            int iWidth = 320;
            int iHeight = 240;

            // The sample code extracts the green channel of a pixel and assign the color only to green channel

            for (int i = 0; i < iWidth ; i++)
            {
                for (int j = 0; j < iHeight ; j++)
                {
                    Color col = ImageArray[i, j];
                    
                    //Get the green element of the color
                    Green = col.G;

                    Color newColor = Color.FromArgb(255, 0, Green, 0);
                    ImageArray[i, j] = newColor;
                   
                }
            }

            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //initialize variable for red value
            byte bRed;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;

            //loop through all pixels
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    //get pixel
                    Color pixel = ImageArray[i, j];

                    //set red value of pixel
                    bRed = pixel.R;

                    //create new filtered colour
                    Color newPixel = Color.FromArgb(255, bRed, 0, 0);
                    ImageArray[i, j] = newPixel;
                }
            }

            //create image and output
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //initialize variable for blue value
            byte bBlue;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;

            //loop through all pixels
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    //get pixel
                    Color pixel = ImageArray[i, j];

                    //set blue value of pixel
                    bBlue = pixel.B;

                    //create new filtered colour
                    Color newPixel = Color.FromArgb(255, 0, 0, bBlue);
                    ImageArray[i, j] = newPixel;
                }
            }

            //create image and output
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnNegative_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //initialize variables for colour values
            byte bRed, bGreen, bBlue;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;

            //loop through all pixels
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    //get pixel
                    Color pixel = ImageArray[i, j];

                    //set colour values of pixel
                    bRed = pixel.R;
                    bGreen = pixel.G;
                    bBlue = pixel.B;

                    //create new negative colour
                    Color newPixel = Color.FromArgb(255, (255 - bRed), (255 - bGreen), (255 - bBlue));
                    ImageArray[i, j] = newPixel;
                }
            }

            //create image and output
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnLighten_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //initialize variables for colour values
            byte bRed, bGreen, bBlue;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;

            //loop through all pixels
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    //get pixel
                    Color pixel = ImageArray[i, j];

                    //set colour values of pixel
                    bRed = pixel.R;
                    bGreen = pixel.G;
                    bBlue = pixel.B;

                    //change pixel channel values
                    bRed = (bRed + 10) > 255 ? bRed : Convert.ToByte(bRed + 10);
                    bGreen = (bGreen + 10) > 255 ? bGreen : Convert.ToByte(bGreen + 10);
                    bBlue = (bBlue + 10) > 255 ? bBlue : Convert.ToByte(bBlue + 10);

                    //create new lightened colour
                    Color newPixel = Color.FromArgb(255, bRed, bGreen, bBlue);
                    ImageArray[i, j] = newPixel;
                }
            }

            //create image and output
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnDarken_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //initialize variables for colour values
            byte bRed, bGreen, bBlue;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;

            //loop through all pixels
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    //get pixel
                    Color pixel = ImageArray[i, j];

                    //set colour values of pixel
                    bRed = pixel.R;
                    bGreen = pixel.G;
                    bBlue = pixel.B;

                    //change pixel channel values
                    bRed = (bRed - 10) < 0 ? bRed : Convert.ToByte(bRed - 10);
                    bGreen = (bGreen - 10) < 0 ? bGreen : Convert.ToByte(bGreen - 10);
                    bBlue = (bBlue - 10) < 0 ? bBlue : Convert.ToByte(bBlue - 10);

                    //create new darkened colour
                    Color newPixel = Color.FromArgb(255, bRed, bGreen, bBlue);
                    ImageArray[i, j] = newPixel;
                }
            }

            //create image and output
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnSunset_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //initialize variables for colour values
            byte bRed, bGreen, bBlue;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;

            //loop through all pixels
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    //get pixel
                    Color pixel = ImageArray[i, j];

                    //set colour values of pixel
                    bRed = pixel.R;
                    bGreen = pixel.G;
                    bBlue = pixel.B;
                    
                    //change pixel channel values
                    bRed = (bRed * 1.25) <= 255 ? Convert.ToByte(bRed * 1.25) : Convert.ToByte(255);
                    bBlue = Convert.ToByte(bBlue * 0.85);
                    bGreen = Convert.ToByte(bGreen * 0.85);

                    //create new sunset colour
                    Color newPixel = Color.FromArgb(255, bRed, bGreen, bBlue);
                    ImageArray[i, j] = newPixel;
                }
            }

            //create image and output
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //initialize variables for colour values
            byte bRed, bGreen, bBlue, bAverage;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;

            //loop through all pixels
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    //get pixel
                    Color pixel = ImageArray[i, j];

                    //set colour values of pixel
                    bRed = pixel.R;
                    bGreen = pixel.G;
                    bBlue = pixel.B;

                    //get average
                    bAverage = Convert.ToByte((bRed + bGreen + bBlue) / 3);

                    //create new grayscale colour
                    Color newPixel = Color.FromArgb(255, bAverage, bAverage, bAverage);
                    ImageArray[i, j] = newPixel;
                }
            }

            //create image and output
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnPolarize_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //initialize variables for colour values
            byte bRed, bGreen, bBlue, bRedAverage, bGreenAverage, bBlueAverage;
            int iRedSum, iGreenSum, iBlueSum;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;

            //set sums to 0
            iRedSum = 0;
            iGreenSum = 0;
            iBlueSum = 0;

            //loop through all pixels
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    //get pixel
                    Color pixel = ImageArray[i, j];

                    //set colour values of pixel
                    bRed = pixel.R;
                    bGreen = pixel.G;
                    bBlue = pixel.B;

                    //get averages
                    iRedSum += bRed;
                    iGreenSum += bGreen;
                    iBlueSum += bBlue;
                }
            }

            //set averages
            bRedAverage = Convert.ToByte(iRedSum / (iWidth * iHeight));
            bBlueAverage = Convert.ToByte(iBlueSum / (iWidth * iHeight));
            bGreenAverage = Convert.ToByte(iGreenSum / (iWidth * iHeight));

            //loop through all pixels
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    //get pixel
                    Color pixel = ImageArray[i, j];

                    //initalize and set min and max
                    byte bMin, bMax;
                    bMin = 0;
                    bMax = 255;

                    //set colour values of pixel
                    bRed = pixel.R;
                    bGreen = pixel.G;
                    bBlue = pixel.B;

                    //set value based on average
                    bRed = (bRed >= bRedAverage) ? bMax : bMin;
                    bGreen = (bGreen >= bGreenAverage) ? bMax : bMin;
                    bBlue = (bBlue >= bBlueAverage) ? bMax : bMin;

                    //create new polarized colour
                    Color newPixel = Color.FromArgb(255, bRed, bGreen, bBlue);
                    ImageArray[i, j] = newPixel;
                }
            }

            //create image and output
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnBlur_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //create temporary image
            Color[,] tmpImage = ImageArray;

            //initialize variable for colour values
            byte bRed, bGreen, bBlue, bCounter;

            //initialize and set sum variables
            int iRedSum, iGreenSum, iBlueSum;
            iRedSum = 0;
            iGreenSum = 0;
            iBlueSum = 0;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;

            //loop through all pixels
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    //reset counter
                    bCounter = 0;

                    //TODO: blur image
                    for (int m = -1; m <= 1; m++)
                    {
                        for (int n = -1; n <= 1; n++)
                        {
                            if ((i + m) >= 0 && (i + m) < iWidth && (j + n) >= 0 && (j + n) < iHeight && !(m == 0 && n == 0))
                            {
                                //get temporary pixel
                                Color tempPixel = tmpImage[(i + m), (j + n)];

                                //add colour values to sum
                                iRedSum += tempPixel.R;
                                iGreenSum += tempPixel.G;
                                iBlueSum += tempPixel.B;

                                //increment counter
                                bCounter++;
                            }
                        }
                    }

                    //get pixel
                    Color pixel = ImageArray[i, j];

                    //set values of pixel
                    bRed = Convert.ToByte(iRedSum / bCounter);
                    bGreen = Convert.ToByte(iGreenSum / bCounter);
                    bBlue = Convert.ToByte(iBlueSum / bCounter);

                    //reset sums
                    iRedSum = 0;
                    iGreenSum = 0;
                    iBlueSum = 0;

                    //create new colour
                    Color newPixel = Color.FromArgb(255, bRed, bGreen, bBlue);
                    ImageArray[i, j] = newPixel;
                }
            }

            //create image and output
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnFlipHorizontal_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //initialize variables for colour values
            int iRed1, iGreen1, iBlue1, iRed2, iGreen2, iBlue2;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;

            //loop through half of all pixels
            for (int i = 0; i < (iWidth/2); i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    //get values of pixels
                    Color pixel1 = ImageArray[i, j];
                    Color pixel2 = ImageArray[(iWidth - 1 - i), j];

                    //set values of pixel colours
                    iRed1 = pixel1.R;
                    iGreen1 = pixel1.G;
                    iBlue1 = pixel1.B;
                    iRed2 = pixel2.R;
                    iGreen2 = pixel2.G;
                    iBlue2 = pixel2.B;

                    //swap values for red
                    iRed1 += iRed2;
                    iRed2 = iRed1 - iRed2;
                    iRed1 -= iRed2;

                    //swap values for green
                    iGreen1 += iGreen2;
                    iGreen2 = iGreen1 - iGreen2;
                    iGreen1 -= iGreen2;

                    //swap values for blue
                    iBlue1 += iBlue2;
                    iBlue2 = iBlue1 - iBlue2;
                    iBlue1 -= iBlue2;

                    //create new colours
                    Color newPixel1 = Color.FromArgb(255, iRed1, iGreen1, iBlue1);
                    ImageArray[i, j] = newPixel1;
                    Color newPixel2 = Color.FromArgb(255, iRed2, iGreen2, iBlue2);
                    ImageArray[(iWidth - 1 - i), j] = newPixel2;
                }
            }

            //create image and output
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnFlipVertical_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //initialize variables for colour values
            int iRed1, iGreen1, iBlue1, iRed2, iGreen2, iBlue2;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;

            //loop through half of all pixels
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < (iHeight / 2); j++)
                {
                    //get values of pixels
                    Color pixel1 = ImageArray[i, j];
                    Color pixel2 = ImageArray[i, (iHeight - 1 - j)];

                    //set values of pixel colours
                    iRed1 = pixel1.R;
                    iGreen1 = pixel1.G;
                    iBlue1 = pixel1.B;
                    iRed2 = pixel2.R;
                    iGreen2 = pixel2.G;
                    iBlue2 = pixel2.B;

                    //swap values for red
                    iRed1 += iRed2;
                    iRed2 = iRed1 - iRed2;
                    iRed1 -= iRed2;

                    //swap values for green
                    iGreen1 += iGreen2;
                    iGreen2 = iGreen1 - iGreen2;
                    iGreen1 -= iGreen2;

                    //swap values for blue
                    iBlue1 += iBlue2;
                    iBlue2 = iBlue1 - iBlue2;
                    iBlue1 -= iBlue2;

                    //create new colours
                    Color newPixel1 = Color.FromArgb(255, iRed1, iGreen1, iBlue1);
                    ImageArray[i, j] = newPixel1;
                    Color newPixel2 = Color.FromArgb(255, iRed2, iGreen2, iBlue2);
                    ImageArray[i, (iHeight - 1 - j)] = newPixel2;
                }
            }

            //create image and output
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //initialize variables for colour values
            int iRed1, iGreen1, iBlue1, iRed2, iGreen2, iBlue2;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;

            //loop through half of all pixels
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < (iHeight / 2); j++)
                {
                    //get values of pixels
                    Color pixel1 = ImageArray[i, j];
                    Color pixel2 = ImageArray[(iWidth - 1 - i), (iHeight - 1 - j)];

                    //set values of pixel colours
                    iRed1 = pixel1.R;
                    iGreen1 = pixel1.G;
                    iBlue1 = pixel1.B;
                    iRed2 = pixel2.R;
                    iGreen2 = pixel2.G;
                    iBlue2 = pixel2.B;

                    //swap values for red
                    iRed1 += iRed2;
                    iRed2 = iRed1 - iRed2;
                    iRed1 -= iRed2;

                    //swap values for green
                    iGreen1 += iGreen2;
                    iGreen2 = iGreen1 - iGreen2;
                    iGreen1 -= iGreen2;

                    //swap values for blue
                    iBlue1 += iBlue2;
                    iBlue2 = iBlue1 - iBlue2;
                    iBlue1 -= iBlue2;

                    //create new colours
                    Color newPixel1 = Color.FromArgb(255, iRed1, iGreen1, iBlue1);
                    ImageArray[i, j] = newPixel1;
                    Color newPixel2 = Color.FromArgb(255, iRed2, iGreen2, iBlue2);
                    ImageArray[(iWidth - 1 - i), (iHeight - 1 - j)] = newPixel2;
                }
            }

            //create image and output
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //initialize variables for colour values
            int iRed1, iGreen1, iBlue1, iRed2, iGreen2, iBlue2;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;

            //loop through half of all pixels
            for (int i = 0; i < (iWidth / 2); i++)
            {
                for (int j = 0; j < (iHeight / 2); j++)
                {
                    //get values of pixels
                    Color pixel1 = ImageArray[i, j];
                    Color pixel2 = ImageArray[((iWidth / 2) + i), ((iHeight / 2) + j)];

                    //set values of pixel colours
                    iRed1 = pixel1.R;
                    iGreen1 = pixel1.G;
                    iBlue1 = pixel1.B;
                    iRed2 = pixel2.R;
                    iGreen2 = pixel2.G;
                    iBlue2 = pixel2.B;

                    //swap values for red
                    iRed1 += iRed2;
                    iRed2 = iRed1 - iRed2;
                    iRed1 -= iRed2;

                    //swap values for green
                    iGreen1 += iGreen2;
                    iGreen2 = iGreen1 - iGreen2;
                    iGreen1 -= iGreen2;

                    //swap values for blue
                    iBlue1 += iBlue2;
                    iBlue2 = iBlue1 - iBlue2;
                    iBlue1 -= iBlue2;

                    //create new colours
                    Color newPixel1 = Color.FromArgb(255, iRed1, iGreen1, iBlue1);
                    ImageArray[i, j] = newPixel1;
                    Color newPixel2 = Color.FromArgb(255, iRed2, iGreen2, iBlue2);
                    ImageArray[((iWidth / 2) + i), ((iHeight / 2) + j)] = newPixel2;
                }
            }

            //create image and output
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnPixellate_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //initialize variables for colour values
            byte bRed, bGreen, bBlue;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;

            //initialize and set tile size variable
            int iTileSize;
            
            //check tile size selected
            if (cbTileSize.SelectedIndex != -1)
            {
                int[] availableSizes = { 2, 4, 8, 10, 20 };
                iTileSize = availableSizes[cbTileSize.SelectedIndex];
            }
            else
            {
                iTileSize = 4;
            }

            //loop through all pixels
            for (int i = 0; i < iWidth; i += iTileSize)
            {
                for (int j = 0; j < iHeight; j += iTileSize)
                {
                    //get value of pixel
                    Color pixel = ImageArray[i, j];

                    //set values of pixel colours
                    bRed = pixel.R;
                    bGreen = pixel.G;
                    bBlue = pixel.B;

                    //set colour to new pixels
                    for (int m = 0; m < iTileSize; m++)
                    {
                        for (int n = 0; n < iTileSize; n++)
                        {
                            Color newPixel = Color.FromArgb(255, bRed, bGreen, bBlue);
                            ImageArray[(i + m), (j + n)] = newPixel;
                        }
                    }
                }
            }

            //create image and output
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //warn user of grayscale
            DialogResult grayscaleWarning = MessageBox.Show("The picture will be converted to grayscale before the sort occurs. Is this fine?", "Warning!", MessageBoxButtons.YesNo);

            //check result
            if (grayscaleWarning == DialogResult.No)
            {
                //exit
                return;
            }

            //initialize variables for colour values
            byte bRed, bGreen, bBlue, bAverage;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;

            //initialize array of average colours
            byte[] bAverages = new byte[iWidth];

            //loop through all pixels
            for (int i = 0; i < iWidth; i++)
            {
                for (int j = 0; j < iHeight; j++)
                {
                    //get pixel
                    Color pixel = ImageArray[i, j];

                    //set colour values of pixel
                    bRed = pixel.R;
                    bGreen = pixel.G;
                    bBlue = pixel.B;

                    //get average
                    bAverage = Convert.ToByte((bRed + bGreen + bBlue) / 3);

                    //add average to array
                    bAverages[j] = bAverage;
                }

                //sort each line
                for (int j = 1; j < iHeight; j++)
                {
                    //copy element to be inserted (red is used though all colours have the same value)
                    byte bValue = bAverages[j];
                    int k = j - 1;

                    //inner loop moving checking if elements must be moved
                    while (k >= 0)
                    {
                        if (bValue < bAverages[k])
                        {
                            //move one space to the right
                            bAverages[k + 1] = bAverages[k];
                        }
                        else
                        {
                            break;
                        }

                        //decrement
                        k--;
                    }

                    //insert value in correct location
                    bAverages[k + 1] = bValue;
                }

                //set sorted array to values of image
                for (int j = 0; j < iHeight; j++)
                {
                    //create new sorted colour
                    Color newPixel = Color.FromArgb(255, bAverages[j], bAverages[j], bAverages[j]);
                    ImageArray[i, j] = newPixel;
                }
            }

            //create image and output
            SetBitmapFromArray();
            picImage.Image = bitmapImage;
        }

        private void btnScroll_Click(object sender, EventArgs e)
        {
            //check that image exists
            if (bitmapImage == null)
            {
                //exit
                return;
            }

            //initialize variables for colour values
            byte bRed, bGreen, bBlue;

            //initialize and set image size variables
            int iWidth, iHeight;
            iWidth = 320;
            iHeight = 240;
        }
    }
}
