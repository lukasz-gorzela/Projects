using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        private Color currentColor = Color.Black;
        private Bitmap drawingBitmap;
        private bool isDrawing = false;
        private Point lastPoint;
        private Stack<Bitmap> undoStack;
        private Stack<Bitmap> redoStack;
        private Rectangle selectionRectangle;
        private Bitmap clipboardBitmap;
        private bool isCutMode = false;
        private bool isCutModeActive = false;
        private bool isFirstCutPointSelected = false;
        private Point firstCutPoint;
        private float currentLineWidth = 1.0f;
        private bool isMovingSelection = false;
        private Point moveOffset;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            drawingBitmap = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            using (Graphics g = Graphics.FromImage(drawingBitmap))
            {
                g.Clear(this.BackColor); 
            }
            undoStack = new Stack<Bitmap>();
            redoStack = new Stack<Bitmap>();
            selectionRectangle = Rectangle.Empty;
            clipboardBitmap = null;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var thicknessForm = new LineThicknessForm(currentLineWidth))
            {
                if (thicknessForm.ShowDialog() == DialogResult.OK)
                {
                    currentLineWidth = thicknessForm.SelectedLineWidth;
                }
            }
        }

        private void buttonChooseColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    currentColor = colorDialog.Color;
                }
            }
        }

        private void buttonEraser_Click(object sender, EventArgs e)
        {
            currentColor = this.BackColor; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
               
                DrawLine(e.Location);
            }
            else if (isMovingSelection)
            {
                
                Point newLocation = new Point(e.X - moveOffset.X, e.Y - moveOffset.Y);

                selectionRectangle.Location = newLocation;

                this.Invalidate(); 
            }
            else if (isFirstCutPointSelected)
            {
                
                selectionRectangle = new Rectangle(
                    Math.Min(firstCutPoint.X, e.Location.X),
                    Math.Min(firstCutPoint.Y, e.Location.Y),
                    Math.Abs(e.Location.X - firstCutPoint.X),
                    Math.Abs(e.Location.Y - firstCutPoint.Y));

                this.Invalidate(); 
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawImage(drawingBitmap, Point.Empty);
            
            if (selectionRectangle != Rectangle.Empty)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawRectangle(pen, selectionRectangle);
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isCutModeActive && e.Button == MouseButtons.Left)
            {
                if (!isFirstCutPointSelected)
                {
                    
                    firstCutPoint = e.Location;
                    isFirstCutPointSelected = true;
                }
                else
                {
                    
                    selectionRectangle = new Rectangle(
                        Math.Min(firstCutPoint.X, e.Location.X),
                        Math.Min(firstCutPoint.Y, e.Location.Y),
                        Math.Abs(e.Location.X - firstCutPoint.X),
                        Math.Abs(e.Location.Y - firstCutPoint.Y));

                    isFirstCutPointSelected = false;
                    isCutModeActive = false; 

                    this.Invalidate(); 
                }
            }
            else if (!isCutModeActive && e.Button == MouseButtons.Left)
            {
                
                if (selectionRectangle.Contains(e.Location))
                {
                    
                    isMovingSelection = true;

                    
                    moveOffset = new Point(e.X - selectionRectangle.X, e.Y - selectionRectangle.Y);
                }
                else
                {
                    
                    isDrawing = true;
                    lastPoint = e.Location;
                }
            }
        }




        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
               
                isDrawing = false;
            }
            else if (isMovingSelection)
            {
                
                isMovingSelection = false;

               
                undoStack.Push(new Bitmap(drawingBitmap));
                redoStack.Clear(); 
            }
        }
        private void buttonUndo_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 1)
            {
                
                redoStack.Push(new Bitmap(drawingBitmap));
                drawingBitmap = undoStack.Pop();
                this.Invalidate(); 
            }
        }

        private void buttonRedo_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
                
                undoStack.Push(new Bitmap(drawingBitmap));
                drawingBitmap = redoStack.Pop();
                this.Invalidate(); 
            }
        }
        private void buttonCut_Click(object sender, EventArgs e)
        {
            
            isCutModeActive = !isCutModeActive;

            if (isCutModeActive)
            {
               
                ResetCutMode();
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (selectionRectangle.Width > 0 && selectionRectangle.Height > 0)
            {
                
                clipboardBitmap = new Bitmap(selectionRectangle.Width, selectionRectangle.Height);
                using (Graphics g = Graphics.FromImage(clipboardBitmap))
                {
                    g.DrawImage(drawingBitmap, 0, 0, selectionRectangle, GraphicsUnit.Pixel);
                }
            }
        }

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            if (clipboardBitmap != null)
            {
                
                undoStack.Push(new Bitmap(drawingBitmap));

                using (Graphics g = Graphics.FromImage(drawingBitmap))
                {
                    g.DrawImage(clipboardBitmap, selectionRectangle.Location);
                }

                this.Invalidate(); 
            }
        }

        private void PerformCut(Point secondCutPoint)
        {
           
            selectionRectangle = new Rectangle(
                Math.Min(firstCutPoint.X, secondCutPoint.X),
                Math.Min(firstCutPoint.Y, secondCutPoint.Y),
                Math.Abs(secondCutPoint.X - firstCutPoint.X),
                Math.Abs(secondCutPoint.Y - firstCutPoint.Y));

            if (selectionRectangle.Width > 0 && selectionRectangle.Height > 0)
            {
                
                CutSelection();
            }

            
            ResetCutMode();
        }
        private void DrawLine(Point currentPoint)
        {
            using (Graphics g = Graphics.FromImage(drawingBitmap))
            {
                using (Pen myPen = new Pen(currentColor, currentLineWidth)) 
                {
                    g.DrawLine(myPen, lastPoint, currentPoint);
                }
            }

            this.Invalidate(); 
            lastPoint = currentPoint;

            undoStack.Push(new Bitmap(drawingBitmap));
            redoStack.Clear(); 
        }

        private void ResetCutMode()
        {
            isFirstCutPointSelected = false;
            selectionRectangle = Rectangle.Empty;
            this.Invalidate();
        }

        private void CutSelection()
        {
            
            clipboardBitmap = new Bitmap(selectionRectangle.Width, selectionRectangle.Height);
            using (Graphics g = Graphics.FromImage(clipboardBitmap))
            {
                g.DrawImage(drawingBitmap, 0, 0, selectionRectangle, GraphicsUnit.Pixel);
            }

           
            using (Graphics g = Graphics.FromImage(drawingBitmap))
            {
                g.FillRectangle(new SolidBrush(this.BackColor), selectionRectangle);
            }

            undoStack.Push(new Bitmap(drawingBitmap));

            selectionRectangle = Rectangle.Empty;
            this.Invalidate();
        }

        private void buttonCutSelection_Click(object sender, EventArgs e)
        {
            if (selectionRectangle.Width > 0 && selectionRectangle.Height > 0)
            {
                
                clipboardBitmap = new Bitmap(selectionRectangle.Width, selectionRectangle.Height);
                using (Graphics g = Graphics.FromImage(clipboardBitmap))
                {
                    g.DrawImage(drawingBitmap, 0, 0, selectionRectangle, GraphicsUnit.Pixel);
                }

                
                using (Graphics g = Graphics.FromImage(drawingBitmap))
                {
                    g.FillRectangle(new SolidBrush(this.BackColor), selectionRectangle);
                }

               
                undoStack.Push(new Bitmap(drawingBitmap));

                selectionRectangle = Rectangle.Empty;
                this.Invalidate();
            }
            else
            {
                MessageBox.Show("Nie wybrano obszaru do wycięcia.");
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Bitmap Image|*.bmp|JPEG Image|*.jpg|GIF Image|*.gif|PNG Image|*.png";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string extension = System.IO.Path.GetExtension(saveFileDialog.FileName);
                    ImageFormat imageFormat = ImageFormat.Bmp; 

                    switch (extension.ToLower())
                    {
                        case ".bmp":
                            imageFormat = ImageFormat.Bmp;
                            break;
                        case ".jpg":
                            imageFormat = ImageFormat.Jpeg;
                            break;
                        case ".gif":
                            imageFormat = ImageFormat.Gif;
                            break;
                        case ".png":
                            imageFormat = ImageFormat.Png;
                            break;
                        default:
                            break;
                    }

                    drawingBitmap.Save(saveFileDialog.FileName, imageFormat);
                }
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Bitmap Image|*.bmp|JPEG Image|*.jpg|GIF Image|*.gif|PNG Image|*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap loadedBitmap = new Bitmap(openFileDialog.FileName);

                    
                    undoStack.Push(new Bitmap(drawingBitmap));

                    
                    drawingBitmap = new Bitmap(loadedBitmap);

                    
                    redoStack.Clear();

                    this.Invalidate(); 
                }
            }
        }
    }
}
