﻿using BAUOtomasyon.BLL.BAUOtomasyonService;
using BAUOtomasyon.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BAUOtomasyon.WinUI
{
    public partial class OgrenciIletisimForm : Form
    {
        OgrenciService _ogrenciService;
        Ogrenci _seciliOgrenci;
        public OgrenciIletisimForm()
        {
            InitializeComponent();
            _ogrenciService = new OgrenciService();
        }

        private void txtOgrenciAdi_TextChanged(object sender, EventArgs e)
        {
            dgrOgrenciListesi.DataSource = null;
            List<Ogrenci> ogrenciListesi = _ogrenciService.ArananOgrenciService(txtOgrenciAdi.Text);
            dgrOgrenciListesi.DataSource = ogrenciListesi;
        }

        private void OgrenciIletisimForm_Load(object sender, EventArgs e)
        {
            dgrOgrenciListesi.DataSource = null;
            List<Ogrenci> ogrenciListesi = _ogrenciService.ArananOgrenciService(txtOgrenciAdi.Text);
            dgrOgrenciListesi.DataSource = ogrenciListesi;

        }

       

        private void dgrOgrenciListesi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int seciliOgrenciID = Convert.ToInt32(dgrOgrenciListesi.SelectedRows[0].Cells["ID"].Value);
            _seciliOgrenci = _ogrenciService.SecilenOgrenci(seciliOgrenciID);
            txtAd.Text = _seciliOgrenci.Adi;
            txtSoyad.Text = _seciliOgrenci.Soyadi;
        }

        private void btnIletisimKaydet_Click(object sender, EventArgs e)
        {

            Iletisim iletisim = new Iletisim();
            iletisim.Adres = txtAdres.Text;
            iletisim.Telefon = txtTelefon.Text;
            iletisim.EMail = txtEMail.Text;
            iletisim.AktifMi = true;
            iletisim.OlusuturulmaTarihi = DateTime.Now;

            _seciliOgrenci.OgrenciIletisimleri.Add(iletisim);
            _ogrenciService.OgrenciUpdate(_seciliOgrenci);

            
        }
    }
}
