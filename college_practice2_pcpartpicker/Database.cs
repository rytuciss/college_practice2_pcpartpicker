﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

using System.Windows;

namespace college_practice2_pcpartpicker
{
    class Database
    {
        //kategoriju listas kai prireiks spausdint interfeise
        private List<string> KategorijuList = new List<string>();
        //kiekviena kompiuterio dalis kaip objektas
        private List<Cooler> CoolerList = new List<Cooler>();
        private List<CPU> CPUList = new List<CPU>();
        private List<GPU> GPUList = new List<GPU>();
        private List<HDD> HDDList = new List<HDD>();
        private List<Korpusas> KorpusasList = new List<Korpusas>();
        private List<MOBO> MOBOList = new List<MOBO>();
        private List<PSU> PSUList = new List<PSU>();
        private List<RAM> RAMList = new List<RAM>();
        private List<SSD> SSDList = new List<SSD>();
        //programa paima is db informacija ir pagal ja sukure objektus
        private SQLiteConnection Conn { get; set; }
        public Database(string a)
        {
            Conn = new SQLiteConnection(a);
        }
        public void CreateObjects()
        {
            Conn.Open();
            //kategorijos objektu kurimas
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT pavadinimas FROM kategorija", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        KategorijuList.Add(Reader.GetString(0));
            //ausintuvu objektu kurimas
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,jungties_tipas FROM cooler", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        CoolerList.Add(new Cooler(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4)));
            //cpu objektu kurimai
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,jungties_tipas,ram_speed_reikalavimai,ram_latency_reikalavimai,galios_reikalavimai FROM cpu", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        CPUList.Add(new CPU(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4), Reader.GetInt32(5), Reader.GetInt32(6), Reader.GetInt32(7)));
            //gpu objektu kurimui
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,jungties_tipas,galios_reikalavimai FROM gpu", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        GPUList.Add(new GPU(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4), Reader.GetInt32(5)));
            //hdd objektu kurimui
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis FROM hdd", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        HDDList.Add(new HDD(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3)));
            //korpusu objektu kurimas
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,montavimo_tipas FROM korpusas", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        KorpusasList.Add(new Korpusas(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4)));
            //mobo objektu kurimui
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,korpuso_tipas,cpu_jungties_tipas,ram_speed_reikalavimai,ram_latency_reikalavimai,ram_jungciu_kiekis,gpu_jungties_tipas,sata_kiekis,mdot2_kiekis,galios_reikalavimai FROM mobo", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        MOBOList.Add(new MOBO(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4), Reader.GetString(5), Reader.GetInt32(7), Reader.GetInt32(8), Reader.GetInt32(9), Reader.GetString(10), Reader.GetInt32(11), Reader.GetInt32(12), Reader.GetInt32(13)));
            //psu objektu kurimui
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,galia,efektyvumas FROM psu", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        PSUList.Add(new PSU(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetInt32(4), Reader.GetInt32(5)));
            //ram objektu kurimui
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,ram_speed,ram_latency,galios_reikalavimai FROM ram", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        RAMList.Add(new RAM(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetInt32(4), Reader.GetInt32(5), Reader.GetInt32(6)));
            //ssd objektu kurimui
            using (SQLiteCommand Comm = new SQLiteCommand(@"SELECT gamintojas,modelis,aprasymas,paveikslelis,tipas FROM ssd", Conn))
                using (SQLiteDataReader Reader = Comm.ExecuteReader())
                    while (Reader.Read())
                        SSDList.Add(new SSD(Reader.GetString(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4)));
            Conn.Close();
        }
        public List<string> GetKategorijuList()
        {
            return KategorijuList;
        }
        public List<Cooler> GetCoolerList()
        {
            return CoolerList;
        }
        public List<CPU> GetCPUList()
        {
            return CPUList;
        }
        public List<GPU> GetGPUList()
        {
            return GPUList;
        }
        public List<HDD> GetHDDList()
        {
            return HDDList;
        }
        public List<Korpusas> GetKorpusuList()
        {
            return KorpusasList;
        }
        public List<MOBO> GetMOBOList()
        {
            return MOBOList;
        }
        public List<PSU> GetPSUList()
        {
            return PSUList;
        }
        public List<RAM> GetRAMList()
        {
            return RAMList;
        }
        public List<SSD> GetSSDList()
        {
            return SSDList;
        }
    }
}
