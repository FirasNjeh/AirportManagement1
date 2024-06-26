﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM1.ApplicationCore.Domain
{
    // 2eme méthode
    //public enum PlaneType
    //{
    //    Boing, Airbus
    //}
    public class Plane
    {
        #region exemple
        //private string name;

        //public void setName(string name) { this.name = name; }
        //public string getName() { return this.name;}
        //Version light
        //public int Id { get; set; }
        //Full version
        //private int myVar;

        //public int MyProperty
        //{
        //    get { return myVar; }
        //    set { myVar = value; }
        //}
        //Version securisé
        //public int MyProperty1 { get; private set; }
        #endregion
        public int PlaneId { get; set; }
        //[Range(1,100)] => Intervalle entre 1 et 100
        [Range(0,int.MaxValue)] //=> entier positif
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public PlaneType PlaneType { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        public override string ToString()
        {
            return "Capacity: " + Capacity+" PlaneType: "+PlaneType +
                " PlaneID: " + PlaneId + " ManufactureDate: " + ManufactureDate;
        }

    }
}
