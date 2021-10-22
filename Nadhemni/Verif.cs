using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadhemni
{
    class Verif
    {
        public static Boolean verifAlpha(String ch) //méthode qui assure que toute la chaîne ne contient que des lettres
        {
            Boolean test = true;
            if (ch.Equals("") || ch.Equals(" "))
                test = false;
            else
            {
                for (int i = 0; i < ch.Length; i++)
                {
                    if (!Char.IsLetter(ch[i]))
                    {
                        test = false;
                        break;
                    }
                }
            }
            return test;
        }
        public static Boolean verifDigit(String ch) //méthode qui assure que toute la chaîne ne contient que des chiffres
        {
            Boolean test = true;
            if (ch.Equals("") || ch.Equals(" "))
                test = false;
            else
            {
                for (int i = 0; i < ch.Length; i++)
                {
                    if (!Char.IsDigit(ch[i]))
                    {
                        test = false;
                        break;
                    }
                }
            }
            return test;
        }

        public static Boolean verifDigitOrAlpha(String ch)
        {
            Boolean test = true;
            if (ch.Equals("") || ch.Equals(" "))
                test = false;
            else
            {
                for (int i = 0; i < ch.Length; i++)
                {
                    if (!Char.IsLetterOrDigit(ch[i]))
                    {
                        test = false;
                        break;
                    }
                }
            }
            return test;

        }

        public static Boolean verifDeadline(DateTime d)
        {
            DateTime today = DateTime.Today;
            Boolean test = true;

            if (d.Equals(today) || d.CompareTo(today) < 0) //si l'utilisateur n'a sélectionné aucune date donc la date d'aujourd'hui est restée sélectionnée ou la date séléctionnée est inférieure à celle d'aujourd'hui (le deadline est déjà dépassé)
            {

                test = false;
            }

            return test;
        }
        public static Boolean verifFloat(String ch) //méthode qui assure que toute la chaîne ne contient que des chiffres
        {
            int ver = 0;
            Boolean test = true;
            if (ch.Equals("") || ch.Equals(" "))
                test = false;
            else
            {
                for (int i = 0; i < ch.Length; i++)
                {
                    if (!Char.IsDigit(ch[i]) && ch[i].Equals(","))
                    {
                        test = false;
                        break;
                    }
                    if (ch[i].Equals(","))
                    {
                        ver = ver + 1;
                    }
                }
                if (ver > 1)
                {
                    test = false;
                }
            }
            return test;
        }

        public static Boolean verifDate(DateTime d)
        {
            DateTime today = DateTime.Today;
            Boolean test = true;

            if (d.Equals(today)) //si l'utilisateur n'a sélectionné aucune date donc la date d'aujourd'hui est restée sélectionnée
            {
                test = false;
            }
            else
            {//Sinon

                if (d.CompareTo(today) > 0)//si la date sélectionnée est supérieure à la date courante
                {
                    test = false;
                }
            }
            return test;
        }

    }
}
