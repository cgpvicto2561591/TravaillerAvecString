using System.Diagnostics.Metrics;
using System.Security.Cryptography;

namespace TravaillerAvecString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet;
            char[] voyelles;
            char[] consonnes;
            string[] textes;

            // Un dictionnaire est comme un tableau sauf que l'index est du type que l'on choisi
            // Ici on prend un string
            // Vous aller souvent voir des techniques similaires en javascript et surtout en JSON
            Dictionary<string, int> comptes = new Dictionary<string, int>();

            // Exemples d'ajout et d'utilisation avec un dictionnaire
            //comptes.Add("Exemple", 1);
            //Console.WriteLine(comptes["Exemple"]);
            //comptes["Exemple"] = comptes["Exemple"] + 1;
            //Console.WriteLine(comptes["Exemple"]);

            // Exemples d'ajouts dans un string
            //string exemple = "Al";
            //exemple += 'l';
            //exemple += "o!";

            alphabet = new char[]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                'à', 'â', 'æ', 'ç', 'é', 'è', 'ê', 'ë', 'î', 'ï', 'ô', 'œ', 'ù', 'û', 'ü'
            };
            voyelles = new char[] { 
                'a', 'e', 'i', 'o', 'u', 'y',
                'à', 'â', 'æ', 
                'é', 'è', 'ê', 'ë', 
                'î', 'ï', 
                'ô', 'œ', 
                'ù', 'û', 'ü' 
             };
            consonnes = new char[] { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm',
                'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z',
                'ç' 
            };

            // Chargez les textes en mémoires avec la méthode fournie
            // le chemin doit comprendre le nom complet du fichier avec un @ devant, exemple:
            // ChargerTexte(@"C:\Users\ftaleb\Cegep\Prog1\TravaillerAvecString\paragraph0.txt");

            // Tester vos méthodes avec des strings simples, puis avec les textes


            // Afficher :
            // Le vocabulaire des trois textes (les mots uniques présents)
            // Le compte et la probabilité pour chaque mot

            string small = "Voici un text simple youpi hourra tout fonctionne fonctionne";
            int countsentence1 = CompterMots(small);
            Console.WriteLine(countsentence1);
            string[] testA = ConstruireVocabulaire(small);
          
              for (int i = 0; i < testA.Length; i++)
            {
                Console.WriteLine(testA[i]);
            }
           
            int voyeye = CompterVoyelles(small);
            Console.WriteLine(voyeye);


        }

        /// <summary>
        /// Compter les mots d'un texte en assumant qu'un mot est suivi d'un espace... sauf le dernier
        /// </summary>
        /// <param name="texte">Le texte à analyser</param>
        /// <returns>Le nombre de mots</returns>
        public static int CompterMots(string texte)
        {
            string teststring = texte;
            string empty = " ";
            int CountA = 0;
            for (int i = 0; i < teststring.Length; i++)
            {
                if (teststring[i] == empty[0])
                {
                    CountA += 1;
                }
            }
            CountA = CountA + 1;
            return CountA;
        }

        /// <summary>
        /// On trouve chaque mot unique qui est dans le texte
        /// </summary>
        /// <param name="texte">Le texte à analyser</param>
        /// <returns>Un tableau de mots uniques</returns>
        public static string[] ConstruireVocabulaire(string texte)
        {
            string[] mots = new string[CompterMots(texte)];
            string[] nonunique = new string[CompterMots(texte)];
            string[] unique = new string[CompterMots(texte)];

            string empty = " ";
            int j = 0;
            for (int i = 0; i < texte.Length; i++)
            {
                if (texte[i] != empty[0])
                {
                    mots[j] += texte[i];
                }
                else
                {
                    j += 1;
                }
            }

            //
            for (int i = 0; i < mots.Length; i++)
            {
                for (int k = 0; k < mots.Length; k++)
                {
                    int b = 0;
                    int v = 0;
                    if (mots[i] == mots[k])
                    {
                       
                        if ( k == mots.Length-1)
                        {
                            if (v == 0 )
                            {
                                
                                nonunique[b] = mots[i];
                                b++;
                                v++;
                            }

                        }
                 

                    }
                }
            }
            int counterB = 0;
           
            for (int i = 0; i < unique.Length; i++)
            {
                int v = 0;
                v = CompterMots(unique[i]);
                if (v > 0)
                {
                    counterB++;
                }
            }
            string[] uniqueNoEmpty = new string[counterB];

            int placerMots = 0;
            for (int i = 0; i < unique.Length; i++)
            {
                int v = 0;
                v = CompterMots(unique[i]);
                if (v > 0)
                {
                    uniqueNoEmpty[placerMots] = unique[i];
                }
            }


            bool simple = true;
            
            for (int i =0; i < mots.Length; i++)
            {
              for(int k = 0; k < uniqueNoEmpty.Length; k++)
                {
                    int v = 0;
                    //if (nonunique[k.Length] < 0)
                    {
                        v++;
                    }
                    if (mots[i] == uniqueNoEmpty[k])
                    {
                        v++;
                    }
                    if (v == 0)
                    {
                        unique[i] = mots[i];
                    }

                }
            }

            
            return unique;
        }



        /// <summary>
        /// Compte les voyelles selon l'alphabet utilisé
        /// </summary>
        /// <param name="texte">Un texte quelconque</param>
        /// <returns>le nombre de voyelles dans le texte</returns>
        public static int CompterVoyelles(string texte)
        {
            int nbVoyelles = 0;
            int j = 0;
           
            for (int i = 0; i < texte.Length; i++)
            {
                if (texte[i] == 'a' || texte[i] == 'e' || texte[i] == 'i' || texte[i] == 'o' || texte[i] == 'u' || texte[i] == 'y' || texte[i] == 'à' || texte[i] == 'â' || texte[i] == 'æ' || texte[i] == 'é' || texte[i] == 'è' || texte[i] == 'ê' || texte[i] == 'ë' || texte[i] == 'î' || texte[i] == 'ï' || texte[i] == 'ô' || texte[i] == 'œ' || texte[i] == 'ù' || texte[i] == 'û' || texte[i] == 'ü') 
                {
                    nbVoyelles += 1;
                }
                //'a' || texte[i] == 'e' || texte[i] == 'i' || texte[i] == 'o' || texte[i] == 'u' || texte[i] == 'y' || texte[i] == 'à' || texte[i] == 'â' || texte[i] == 'æ' || texte[i] == 'é' || texte[i] == 'è' || texte[i] == 'ê' || texte[i] == 'ë' || texte[i] == 'î' || texte[i] == 'ï' || texte[i] == 'ô' || texte[i] == 'œ' || texte[i] == 'ù' || texte[i] == 'û' || texte[i] == 'ü'

            }


            return nbVoyelles;
        }

        /// <summary>
        /// Enlève tout caractère qui n'est pas dans l'alphabet pour l'attribut texte
        /// et le remplace par un espace
        /// </summary>
        public static string EnleverCaractreSpeciaux(string texte)
        {
            string textePropre = "";


            return textePropre;
        }

        /// <summary>
        /// Compter le nombre d'occurences d'un mot du texte en assumant qu'un mot est suivi d'un espace
        /// Enlever les caractères spéciaux avant de traiter le texte
        /// </summary>
        /// <param name="texte">Le texte à analyser</param>
        /// <returns>Le nombre de mots</returns>
        public static Dictionary<string, int> CompterOccurencesMots(string texte)
        {
            Dictionary<string, int> occurences = new Dictionary<string, int>();



            return occurences;
        }

        /// <summary>
        /// La probabilité qu'un mot apparaisse dans un texte
        /// p = nb occurences du mot / nb mots
        /// </summary>
        /// <returns>La probabilité arrondie à 3 chiffres après la virgule</returns>
        public static double CalculerProbabiliteMot(/* à compléter */)
        {
            double p = 0;


            return p;
        }

        /// <summary>
        /// Charge un texte dans un string.
        /// </summary>
        /// <param name="chemin">Le chemin complet du fichier</param>
        /// <returns>Un string avec le texte ou un texte vide s'il y a eu une erreur</returns>
        public static string ChargerTexte(string chemin)
        {
            try
            {
                return File.ReadAllText(chemin);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors du chargement du fichier.");
                Console.WriteLine("Vérifier le chemin du fichier.");
                return string.Empty;
            }
        }
    }
}
