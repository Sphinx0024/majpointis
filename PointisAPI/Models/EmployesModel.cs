﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PointisData;
using Zen.Barcode;

namespace PointisAPI.Models
{
    public class EmployesModel
    {
        public static List<Employes> afficher()
        {
            using(PointisEntities _db = new PointisEntities())
            {
                List<Employes> donnees = (from p in _db.Employes
                                              select p).ToList();
                return donnees;
            }
        }

        public static List<Employes> AfficherUnSeul(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Employes> donnees = (from p in _db.Employes
                                          where p.EmployeID == id
                                      select p).ToList();
                return donnees;
            }

        }


        public static void Ajouter(Employes employes)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                _db.Employes.Add(employes);
                _db.SaveChanges();
            }

        }

        public static void Modifier(long id,Employes employes) {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Employes> donnees = (from p in _db.Employes
                                          where p.EmployeID == id
                                          select p).ToList();

                foreach(Employes emp in donnees)
                {
                    emp.Nom = employes.Nom;
                    emp.Prenom = employes.Prenom;
                    emp.Email = employes.Email;
                    emp.Telephone = employes.Telephone;
                    emp.Sexe = employes.Sexe;
                }
            }
        }

        public static void supprimer(long id)
        {
            using(PointisEntities _db = new PointisEntities())
            {
                List<Employes> donnees = (from p in _db.Employes
                                          where p.EmployeID == id
                                          select p).ToList();

                _db.Employes.RemoveRange(donnees);
                _db.SaveChanges();
            }
        }

        public static System.Drawing.Image GenererQrcode(Employes employes)
        {
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            var infos = (employes.Nom + " " + employes.Prenom + " " + employes.Telephone + " " + employes.Email + " " + employes.Sexe);
            var result = qrcode.Draw(infos,60);

            return result;
        }

    }
}