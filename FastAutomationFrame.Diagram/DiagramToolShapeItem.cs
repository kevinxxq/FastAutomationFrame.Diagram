﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastAutomationFrame.Diagram
{
    internal class DiagramToolShapeItem : Panel
    {
        #region Fields

        protected Font font = new Font("Verdana", 10F);

        #endregion

        #region Properties

        private int _height = 38;
        public new int Height
        {
            get
            {
                return _height;
            }
        }

        #endregion

        public ShapeBase Shape { get; set; }

        public DiagramToolShapeItem(ShapeBase shape)
            : base()
        {
            shape.X = 0;
            shape.Y = 0;
            shape.Height = _height - 10;
            shape.Width = _height - 10;

            base.Height = _height;
            Shape = shape;
            this.Dock = DockStyle.Top;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            DragDropEffects dropEffect = this.DoDragDrop(new DragItem() 
                {
                    Shape = Shape 
                },
                DragDropEffects.Copy);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Shape != null)
            {
                Shape.Paint(e.Graphics);
                e.Graphics.DrawString(Shape.ShapeName, font, Brushes.Black, _height + 10, 10);
            }
        }
    }
    internal class DragItem
    {
        public ShapeBase Shape { get; set; }
    }
}
