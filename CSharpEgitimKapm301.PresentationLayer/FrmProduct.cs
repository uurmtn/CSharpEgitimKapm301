using CSharpEgitimKapm301.BusinessLayer.Abstract;
using CSharpEgitimKapm301.BusinessLayer.Concrete;
using CSharpEgitimKapm301.DataAccessLayer.Abstract;
using CSharpEgitimKapm301.DataAccessLayer.EntityFramework;
using CSharpEgitimKapm301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKapm301.PresentationLayer
{
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public FrmProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetAll();
            dataGridView1.DataSource = values;
        }

        private void btnList2_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductsWithCategoriy();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            product.ProductPrice = decimal.Parse(txtProductPrice.Text);
            product.ProductName = txtProductName.Text;
            product.ProductDescription = txtDescription.Text;
            product.ProductStock = int.Parse(txtProductStock.Text);
            _productService.TInsert(product);
            MessageBox.Show("Ekleme başarılı");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var values = _productService.TGetById(id);
            _productService.TDelete(values);
            MessageBox.Show("Silme işlemi başarılı");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var values = _productService.TGetById(id);
            dataGridView1.DataSource = values;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            value.CategoryId = int.Parse(cmbCategory.SelectedValue.ToString());
            value.ProductDescription = txtDescription.Text;
            value.ProductPrice = decimal.Parse(txtProductPrice.Text);
            value.ProductName = txtProductName.Text;
            value.ProductStock = int.Parse(txtProductStock.Text);
            _productService.TUpdate(value);
            MessageBox.Show("Güncelleme başarılı");
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {   
            var values= _categoryService.TGetAll();
            cmbCategory.DataSource= values;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
        }
    }
}
