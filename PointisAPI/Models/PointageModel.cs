using PointisData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointisAPI.Models
{
    public class PointageModel
    {
        public static List<Pointage> afficher()
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Pointage> donnees = (from p in _db.Pointage
                                          select p).ToList();
                return donnees;
            }
        }

        public static List<Pointage> AfficherUnSeul(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Pointage> donnees = (from p in _db.Pointage
                                          where p.PointageID == id
                                          select p).ToList();
                return donnees;
            }

        }


        public static void Ajouter(Pointage pointage)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                _db.Pointage.Add(pointage);
                _db.SaveChanges();
            }

        }

        public static void Modifier(long id, Pointage pointage)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Pointage> donnees = (from p in _db.Pointage
                                          where p.PointageID == id
                                          select p).ToList();

                foreach (Pointage point in donnees)
                {
                    point.Jour = pointage.Jour;
                    point.HeureEntree = pointage.HeureEntree;
                    point.HeureSortie = pointage.HeureSortie;
                }
            }
        }

        public static void supprimer(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Pointage> donnees = (from p in _db.Pointage
                                          where p.PointageID == id
                                          select p).ToList();

                _db.Pointage.RemoveRange(donnees);
                _db.SaveChanges();
            }
        }
    }
}