using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrulliManager.Database.Models;

namespace TrulliManager.Database
{
    public static class TrulliSeedData
    {
        public static void EnsureSeedData(this TrulliContext db)
        {
            if(!db.Properties.Any() || !db.Trulli.Any())
            {

                var properties = new List<Property>
                {
                    new Property
                    {
                        Name = "Trulli Don Antonio",
                        City = "Locorotondo",
                        Street = "S.C. 21 C.da Crocifisso n. 9",
                        Spa = true,
                        SwimmingPool = false,
                        Trulli = new List<Trullo>
                        {
                            new Trullo
                            {
                                Name = "Trullo Panoramico",
                                Description = "Trullo con soppalco con 2 camere da letto e 2 bagni",
                                Capacity = 4,
                                Price = 100
                            },
                            new Trullo
                            {
                                Name = "Trullo dell'Interprete",
                                Description = "Trullo in ambiente unico con 1 camera da letto e 1 bagno",
                                Capacity = 3,
                                Price = 80
                            },
                            new Trullo
                            {
                                Name = "Trullo dell'Arco",
                                Description = "Trullo ampio con 2 camere da letto e 1 bagno",
                                Capacity = 4,
                                Price = 120
                            }
                        }
                    },
                    new Property
                    {
                        Name = "Trulli Cinquenoci",
                        City = "Locorotondo",
                        Street = "S.C. 126 C.da Cinquenoci n. 6",
                        Spa = false,
                        SwimmingPool = true,
                        Trulli = new List<Trullo>
                        {
                            new Trullo
                            {
                                Name = "Trullo Mille Volte",
                                Description = "Trullo a volte in pietra con 3 camere da letto e 2 bagni",
                                Capacity = 7,
                                Price = 180
                            },
                            new Trullo
                            {
                                Name = "Trullo Romantico",
                                Description = "Trullo in ambiente unico con 1 camera da letto e 1 bagno",
                                Capacity = 2,
                                Price = 60
                            },
                            new Trullo
                            {
                                Name = "Trullo Nuovo",
                                Description = "Trullo di nuova costruzione con 2 camere da letto e 1 bagno",
                                Capacity = 4,
                                Price = 120
                            }
                        }
                    },
                    new Property
                    {
                        Name = "Casa del Carbonaio",
                        City = "Locorotondo",
                        Street = "Via Garibaldi n. 17",
                        Spa = false,
                        SwimmingPool = false,
                        Trulli = new List<Trullo>
                        {
                            new Trullo
                            {
                                Name = "Trullo del Carbonaio",
                                Description = "Trullo a volte in pietra nel centro storico con 1 camera da letto e 2 bagni",
                                Capacity = 7,
                                Price = 110
                            }
                        }
                    }
                };

                db.Properties.AddRange(properties);
                db.SaveChanges();

            }
        }
    }
}
