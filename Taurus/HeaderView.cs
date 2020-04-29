using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;

public partial class HeaderView : DataGridView
{
  private TreeView[] _columnTreeView;
  private ArrayList _columnList = new ArrayList();
  private int _cellHeight = 17;

  public int CellHeight
  {
    get { return _cellHeight; }
    set { _cellHeight = value; }
  }
  private int _columnDeep = 1;
  private bool HscrollRefresh = false;
  /// <summary>  
  /// ˮƽ����ʱ�Ƿ�ˢ�±�ͷ�����ݽ϶�ʱ���ܻ���˸����ˢ��ʱ������ʾ����  
  /// </summary>  
  [Description("ˮƽ����ʱ�Ƿ�ˢ�±�ͷ�����ݽ϶�ʱ���ܻ���˸����ˢ��ʱ������ʾ����")]
  public bool RefreshAtHscroll
  {
    get { return HscrollRefresh; }
    set { HscrollRefresh = value; }
  }
  /// <summary>
  /// ���캯��
  /// </summary>
  public HeaderView()
  {
    //InitializeComponent();
    this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
    //�����и߶���ʾģʽ              
  }
  public HeaderView(IContainer container)
  {
    container.Add(this);
    //InitializeComponent();
  }

  [Description("���û��úϲ���ͷ�������")]
  public int ColumnDeep
  {
    get
    {
      if (this.Columns.Count == 0) _columnDeep = 1;
      this.ColumnHeadersHeight = _cellHeight * _columnDeep;
      return _columnDeep;
    }
    set
    {
      if (value < 1)
        _columnDeep = 1;
      else
        _columnDeep = value;
      this.ColumnHeadersHeight = _cellHeight * _columnDeep;
    }
  }

  [Description("��Ӻϲ�ʽ��Ԫ����Ƶ�����Ҫ�Ľڵ����")]
  public TreeView[] ColumnTreeView
  {
    get { return _columnTreeView; }
    set
    {
      if (_columnTreeView != null)
      {
        for (int i = 0; i <= _columnTreeView.Length - 1; i++)
          _columnTreeView[i].Dispose();
      }
      _columnTreeView = value;
    }
  }

  [Description("������ӵ��ֶ������������")]
  public TreeView ColumnTreeViewNode
  {
    get { return _columnTreeView[0]; }
  }

  /// <summary>
  /// ���û��ȡ�ϲ��еļ���
  /// </summary>
  [MergableProperty(false)]
  [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
  [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
  [Localizable(true)]
  [Description("���û��ȡ�ϲ��еļ���"), Browsable(true), Category("��Ԫ��ϲ�")]
  public List<string> MergeColumnNames
  {
    get { return _mergecolumnname; }
    set { _mergecolumnname = value; }
  }
  private List<string> _mergecolumnname = new List<string>();

  public ArrayList NadirColumnList
  {
    get
    {
      if (_columnTreeView == null) return null;
      if (_columnTreeView[0] == null) return null;
      if (_columnTreeView[0].Nodes == null) return null;
      if (_columnTreeView[0].Nodes.Count == 0) return null;
      _columnList.Clear();
      GetNadirColumnNodes(_columnList, _columnTreeView[0].Nodes[0], false);
      return _columnList;
    }
  }
  ///<summary>  
  ///���ƺϲ���ͷ  
  ///</summary>  
  ///<param name="node">�ϲ���ͷ�ڵ�</param>  
  ///<param name="e">��ͼ������</param>  
  ///<param name="level">������</param>  
  ///<remarks></remarks>  
  public void PaintUnitHeader(TreeNode node, System.Windows.Forms.DataGridViewCellPaintingEventArgs e, int level)
  {
    //���ڵ�ʱ�˳��ݹ����  
    if (level == 0) return;
    RectangleF uhRectangle;
    int uhWidth;
    SolidBrush gridBrush = new SolidBrush(this.GridColor);
    SolidBrush backColorBrush = new SolidBrush(e.CellStyle.BackColor);
    Pen gridLinePen = new Pen(gridBrush);
    StringFormat textFormat = new StringFormat();
    textFormat.Alignment = StringAlignment.Center;
    uhWidth = GetUnitHeaderWidth(node);
    if (node.Nodes.Count == 0)
    {
      uhRectangle = new Rectangle(e.CellBounds.Left, e.CellBounds.Top + node.Level * _cellHeight, uhWidth - 1,
        _cellHeight * (_columnDeep - node.Level) - 1);
    }
    else
    {
      uhRectangle = new Rectangle(e.CellBounds.Left, e.CellBounds.Top + node.Level * _cellHeight, uhWidth - 1,
        _cellHeight - 1);
    }
    //������  
    e.Graphics.FillRectangle(backColorBrush, uhRectangle);
    //������  
    e.Graphics.DrawLine(gridLinePen, uhRectangle.Left, uhRectangle.Bottom, uhRectangle.Right, uhRectangle.Bottom);
    //���Ҷ���  
    e.Graphics.DrawLine(gridLinePen, uhRectangle.Right, uhRectangle.Top, uhRectangle.Right, uhRectangle.Bottom);
    ////д�ֶ��ı�  
    e.Graphics.DrawString(node.Text, this.Font, new SolidBrush(e.CellStyle.ForeColor),
      uhRectangle.Left + uhRectangle.Width / 2 - e.Graphics.MeasureString(node.Text, this.Font).Width / 2 - 1,
      uhRectangle.Top + uhRectangle.Height / 2 - e.Graphics.MeasureString(node.Text, this.Font).Height / 2);
    //�ݹ����()  
    if (node.PrevNode == null)
      if (node.Parent != null)
        PaintUnitHeader(node.Parent, e, level - 1);
  }
  /// <summary>  
  /// ��úϲ������ֶεĿ��  
  /// </summary>  
  /// <param name="node">�ֶνڵ�</param>  
  /// <returns>�ֶο��</returns>  
  /// <remarks></remarks>  
  private int GetUnitHeaderWidth(TreeNode node)
  {
    //��÷���ײ��ֶεĿ��  
    int uhWidth = 0;
    //�����ײ��ֶεĿ��  
    if (node.Nodes == null) return this.Columns[GetColumnListNodeIndex(node)].Width;

    if (node.Nodes.Count == 0) return this.Columns[GetColumnListNodeIndex(node)].Width;

    for (int i = 0; i <= node.Nodes.Count - 1; i++)
    {
      uhWidth = uhWidth + GetUnitHeaderWidth(node.Nodes[i]);
    }
    return uhWidth;
  }
  /// <summary>  
  /// ��õײ��ֶ�����  
  /// </summary>  
  ///' <param name="node">�ײ��ֶνڵ�</param>  
  /// <returns>����</returns>  
  /// <remarks></remarks>  
  private int GetColumnListNodeIndex(TreeNode node)
  {
    for (int i = 0; i <= _columnList.Count - 1; i++)
    {
      if (((TreeNode)_columnList[i]).Equals(node)) return i;
    }
    return -1;
  }
  /// <summary>  
  /// ��õײ��ֶμ���  
  /// </summary>  
  /// <param name="alList">�ײ��ֶμ���</param>  
  /// <param name="node">�ֶνڵ�</param>  
  /// <param name="checked">�����������</param>  
  /// <remarks></remarks>  
  private void GetNadirColumnNodes(ArrayList alList, TreeNode node, Boolean isChecked)
  {
    if (isChecked == false)
    {
      if (node.FirstNode == null)
      {
        alList.Add(node);
        if (node.NextNode != null)
        {
          GetNadirColumnNodes(alList, node.NextNode, false);
          return;
        }
        if (node.Parent != null)
        {
          GetNadirColumnNodes(alList, node.Parent, true);
          return;
        }
      }
      else
      {
        if (node.FirstNode != null)
        {
          GetNadirColumnNodes(alList, node.FirstNode, false);
          return;
        }
      }
    }
    else
    {
      if (node.FirstNode == null)
      {
        return;
      }
      else
      {
        if (node.NextNode != null)
        {
          GetNadirColumnNodes(alList, node.NextNode, false);
          return;
        }

        if (node.Parent != null)
        {
          GetNadirColumnNodes(alList, node.Parent, true);
          return;
        }
      }
    }
  }
  /// <summary>  
  /// ����  
  /// </summary>  
  /// <param name="e"></param>  
  protected override void OnScroll(ScrollEventArgs e)
  {
    bool scrollDirection = (e.ScrollOrientation == ScrollOrientation.HorizontalScroll);
    base.OnScroll(e);
    if (RefreshAtHscroll && scrollDirection) this.Refresh();
  }
  /// <summary>  
  /// �п�ȸı����д  
  /// </summary>  
  /// <param name="e"></param>  
  protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
  {
    Graphics g = Graphics.FromHwnd(this.Handle);
    float uwh = g.MeasureString(e.Column.HeaderText, this.Font).Width;
    if (uwh >= e.Column.Width) { e.Column.Width = Convert.ToInt16(uwh); }
    base.OnColumnWidthChanged(e);
  }
  /// <summary>  
  /// ��Ԫ�����(��д)  
  /// </summary>  
  /// <param name="e"></param>  
  /// <remarks></remarks>  
  protected override void OnCellPainting(System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
  {
    try
    {
      if (e.RowIndex > -1 && e.ColumnIndex > -1)
      {
        DrawCell(e);
      }
      else
      {
        //�б��ⲻ��д  
        if (e.ColumnIndex < 0)
        {
          base.OnCellPainting(e);
          return;
        }

        if (_columnDeep == 1)
        {
          base.OnCellPainting(e);
          return;
        }

        //���Ʊ�ͷ  
        if (e.RowIndex == -1)
        {
          if (e.ColumnIndex >= NadirColumnList.Count)
          {
            e.Handled = true;
            return;
          }
          PaintUnitHeader((TreeNode)NadirColumnList[e.ColumnIndex], e, _columnDeep);
          e.Handled = true;
        }
      }
    }
    catch
    {
    }
  }

  #region �ϲ���Ԫ��
  /// <summary>
  /// ����Ԫ��
  /// </summary>
  /// <param name="e"></param>
  private void DrawCell(DataGridViewCellPaintingEventArgs e)
  {
    if (e.CellStyle.Alignment == DataGridViewContentAlignment.NotSet)
    {
      e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
    }
    Brush gridBrush = new SolidBrush(this.GridColor);
    SolidBrush backBrush = new SolidBrush(e.CellStyle.BackColor);
    SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
    int cellwidth;
    //������ͬ������
    int UpRows = 0;
    //������ͬ������
    int DownRows = 0;
    //������
    int count = 0;
    if (this.MergeColumnNames.Contains(this.Columns[e.ColumnIndex].Name) && e.RowIndex != -1)
    {
      cellwidth = e.CellBounds.Width;
      Pen gridLinePen = new Pen(gridBrush);
      string curValue = e.Value == null ? "" : e.Value.ToString().Trim();
      string curSelected = this.CurrentRow.Cells[e.ColumnIndex].Value == null ? "" : this.CurrentRow.Cells[e.ColumnIndex].Value.ToString().Trim();
      if (!string.IsNullOrEmpty(curValue))
      {
        #region ��ȡ���������
        for (int i = e.RowIndex; i < this.Rows.Count; i++)
        {
          if (this.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
          {
            DownRows++;
            if (e.RowIndex != i)
            {
              cellwidth = cellwidth < this.Rows[i].Cells[e.ColumnIndex].Size.Width ? cellwidth : this.Rows[i].Cells[e.ColumnIndex].Size.Width;
            }
          }
          else
          {
            break;
          }
        }
        #endregion
        #region ��ȡ���������
        for (int i = e.RowIndex; i >= 0; i--)
        {
          if (this.Rows[i].Cells[e.ColumnIndex].Value.ToString().Equals(curValue))
          {
            UpRows++;
            if (e.RowIndex != i)
            {
              cellwidth = cellwidth < this.Rows[i].Cells[e.ColumnIndex].Size.Width ? cellwidth : this.Rows[i].Cells[e.ColumnIndex].Size.Width;
            }
          }
          else
          {
            break;
          }
        }
        #endregion
        count = DownRows + UpRows - 1;
        if (count < 2)
        {
          return;
        }
      }
      if (this.Rows[e.RowIndex].Selected)
      {
        backBrush.Color = e.CellStyle.SelectionBackColor;
        fontBrush.Color = e.CellStyle.SelectionForeColor;
      }
      //�Ա���ɫ���
      e.Graphics.FillRectangle(backBrush, e.CellBounds);
      //���ַ���
      PaintingFont(e, cellwidth, UpRows, DownRows, count);
      if (DownRows == 1)
      {
        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
        count = 0;
      }
      // ���ұ���
      e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
      e.Handled = true;
    }
  }
  /// <summary>
  /// ���ַ���
  /// </summary>
  /// <param name="e"></param>
  /// <param name="cellwidth"></param>
  /// <param name="UpRows"></param>
  /// <param name="DownRows"></param>
  /// <param name="count"></param>
  private void PaintingFont(System.Windows.Forms.DataGridViewCellPaintingEventArgs e, int cellwidth, int UpRows,
    int DownRows, int count)
  {
    SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
    int fontheight = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Height;
    int fontwidth = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
    int cellheight = e.CellBounds.Height;

    if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomCenter)
    {
      e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y + cellheight * DownRows - fontheight);
    }
    else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomLeft)
    {
      e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y + cellheight * DownRows - fontheight);
    }
    else if (e.CellStyle.Alignment == DataGridViewContentAlignment.BottomRight)
    {
      e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y + cellheight * DownRows - fontheight);
    }
    else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)
    {
      e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
    }
    else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleLeft)
    {
      e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
    }
    else if (e.CellStyle.Alignment == DataGridViewContentAlignment.MiddleRight)
    {
      e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
    }
    else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopCenter)
    {
      e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1));
    }
    else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopLeft)
    {
      e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X, e.CellBounds.Y - cellheight * (UpRows - 1));
    }
    else if (e.CellStyle.Alignment == DataGridViewContentAlignment.TopRight)
    {
      e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + cellwidth - fontwidth, e.CellBounds.Y - cellheight * (UpRows - 1));
    }
    else
    {
      e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, fontBrush, e.CellBounds.X + (cellwidth - fontwidth) / 2, e.CellBounds.Y - cellheight * (UpRows - 1) + (cellheight * count - fontheight) / 2);
    }
  }
  #endregion
}