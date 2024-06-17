using Beadandó;

namespace BeadandóTeszt
{
    public class Tests
    {
        private Városvezetés városvezetés;

        [SetUp]
        public void Setup()
        {
            városvezetés = new Városvezetés();
        }

        [Test]
        public void NincsTúrista()
        {
            városvezetés.Újév(50, 0, 0, 0);
            Assert.That(városvezetés.városÉvei[0].állapot.ToString(), Is.EqualTo("Átlagos"));
            Assert.That(városvezetés.városÉvei[0].tervezett[0], Is.EqualTo(0));
            Assert.That(városvezetés.városÉvei[0].tervezett[1], Is.EqualTo(0));
            Assert.That(városvezetés.városÉvei[0].tervezett[2], Is.EqualTo(0));
            Assert.That(városvezetés.városÉvei[0].aktuális[0], Is.EqualTo(0));
            Assert.That(városvezetés.városÉvei[0].aktuális[1], Is.EqualTo(0));
            Assert.That(városvezetés.városÉvei[0].aktuális[2], Is.EqualTo(0));
            Assert.That(városvezetés.városÉvei[0].bevétel, Is.EqualTo((nint)0));
        }

        [Test]
        public void CsakJapán()
        {
            int pont = 50;
            int[] évek = new int[]
            {
                300000 , 200000 , 600000
            };
            string[] eredmények = new string[]
            {
                "Jó", "Jó", "Jó"
            };
            int[] aktuális = new int[]
            {
                300000 , 240000 , 720000
            };
            ulong[] pénzek = new ulong[]
            {
                27500000000 , 24000000000 , 72000000000
            };
            for (int i = 0; i < 3; i++)
            {
                pont = városvezetés.Újév(pont, évek[i], 0, 0);
                Assert.That(városvezetés.városÉvei[i].állapot.ToString(), Is.EqualTo(eredmények[i]));
                Assert.That(városvezetés.városÉvei[i].tervezett[0], Is.EqualTo(évek[i]));
                Assert.That(városvezetés.városÉvei[i].tervezett[1], Is.EqualTo(0));
                Assert.That(városvezetés.városÉvei[i].tervezett[2], Is.EqualTo(0));
                Assert.That(városvezetés.városÉvei[i].aktuális[0], Is.EqualTo(aktuális[i]));
                Assert.That(városvezetés.városÉvei[i].aktuális[1], Is.EqualTo(0));
                Assert.That(városvezetés.városÉvei[i].aktuális[2], Is.EqualTo(0));
                Assert.That(városvezetés.városÉvei[i].bevétel, Is.EqualTo((nint)pénzek[i]));
            }
        }

        [Test]
        public void MindenféleTúrista()
        {
            int pont = 50;
            int[,] évek = new int[,]
            {
                {1000 , 4000 , 6000},
                {2000 , 3000 , 8000},
                {6500 , 5000 , 3000}
            };
            string[] eredmények = new string[]
            {
                "Lepusztult", "Lepusztult", "Lepusztult"
            };
            int[,] aktuális = new int[,]
            {
                {1000 , 4400 , 6600},
                {0 , 3000 , 8000},
                {0 , 5000 , 3000}
            };
            ulong[] pénzek = new ulong[]
            {
                1200000000 , 1100000000 , 800000000
            };
            for (int i = 0; i < 3; i++)
            {
                pont = városvezetés.Újév(pont, évek[i, 0], évek[i, 1], évek[i, 2]);
                Assert.That(városvezetés.városÉvei[i].állapot.ToString(), Is.EqualTo(eredmények[i]));
                Assert.That(városvezetés.városÉvei[i].tervezett[0], Is.EqualTo(évek[i, 0]));
                Assert.That(városvezetés.városÉvei[i].tervezett[1], Is.EqualTo(évek[i, 1]));
                Assert.That(városvezetés.városÉvei[i].tervezett[2], Is.EqualTo(évek[i, 2]));
                Assert.That(városvezetés.városÉvei[i].aktuális[0], Is.EqualTo(aktuális[i, 0]));
                Assert.That(városvezetés.városÉvei[i].aktuális[1], Is.EqualTo(aktuális[i, 1]));
                Assert.That(városvezetés.városÉvei[i].aktuális[2], Is.EqualTo(aktuális[i, 2]));
                Assert.That(városvezetés.városÉvei[i].bevétel, Is.EqualTo((nint)pénzek[i]));
            }
        }

        [Test]
        public void LegtöbbJapán()
        {
            int pont = 50;
            int[,] évek = new int[,]
            {
                {1000000 , 4000 , 6000},
                {20000 , 3000 , 8000},
                {65000 , 5000 , 3000}
            };
            string[] eredmények = new string[]
            {
                "Jó", "Átlagos", "Lepusztult"
            };
            int[,] aktuális = new int[,]
            {
                {1000000 , 4400 , 6600},
                {24000 , 3900 , 8000},
                {65000 , 5500 , 3300}
            };
            ulong[] pénzek = new ulong[]
            {
                95750000000 , 3590000000 , 7380000000
            };
            for (int i = 0; i < 3; i++)
            {
                pont = városvezetés.Újév(pont, évek[i, 0], évek[i, 1], évek[i, 2]);
                Assert.That(városvezetés.városÉvei[i].állapot.ToString(), Is.EqualTo(eredmények[i]));
                Assert.That(városvezetés.városÉvei[i].tervezett[0], Is.EqualTo(évek[i, 0]));
                Assert.That(városvezetés.városÉvei[i].tervezett[1], Is.EqualTo(évek[i, 1]));
                Assert.That(városvezetés.városÉvei[i].tervezett[2], Is.EqualTo(évek[i, 2]));
                Assert.That(városvezetés.városÉvei[i].aktuális[0], Is.EqualTo(aktuális[i, 0]));
                Assert.That(városvezetés.városÉvei[i].aktuális[1], Is.EqualTo(aktuális[i, 1]));
                Assert.That(városvezetés.városÉvei[i].aktuális[2], Is.EqualTo(aktuális[i, 2]));
                Assert.That(városvezetés.városÉvei[i].bevétel, Is.EqualTo((nint)pénzek[i]));
            }
        }

        [Test]
        public void LegtöbbNyugati()
        {
            int pont = 50;
            int[,] évek = new int[,]
            {
                {1000 , 400000 , 6000},
                {2000 , 300000 , 8000},
                {6500 , 500000 , 3000}
            };
            string[] eredmények = new string[]
            {
                "Lepusztult", "Lepusztult", "Lepusztult"
            };
            int[,] aktuális = new int[,]
            {
                {1000 , 440000 , 6600},
                {0 , 300000 , 8000},
                {0 , 500000 , 3000}
            };
            ulong[] pénzek = new ulong[]
            {
                20010000000 , 20000000000 , 20000000000
            };
            for (int i = 0; i < 3; i++)
            {
                pont = városvezetés.Újév(pont, évek[i, 0], évek[i, 1], évek[i, 2]);
                Assert.That(városvezetés.városÉvei[i].állapot.ToString(), Is.EqualTo(eredmények[i]));
                Assert.That(városvezetés.városÉvei[i].tervezett[0], Is.EqualTo(évek[i, 0]));
                Assert.That(városvezetés.városÉvei[i].tervezett[1], Is.EqualTo(évek[i, 1]));
                Assert.That(városvezetés.városÉvei[i].tervezett[2], Is.EqualTo(évek[i, 2]));
                Assert.That(városvezetés.városÉvei[i].aktuális[0], Is.EqualTo(aktuális[i, 0]));
                Assert.That(városvezetés.városÉvei[i].aktuális[1], Is.EqualTo(aktuális[i, 1]));
                Assert.That(városvezetés.városÉvei[i].aktuális[2], Is.EqualTo(aktuális[i, 2]));
                Assert.That(városvezetés.városÉvei[i].bevétel, Is.EqualTo((nint)pénzek[i]));
            }
        }

        [Test]
        public void LegtöbbEgyéb()
        {
            int pont = 50;
            int[,] évek = new int[,]
            {
                {1000 , 4000 , 600000},
                {2000 , 3000 , 800000},
                {6500 , 5000 , 300000}
            };
            string[] eredmények = new string[]
            {
                "Lepusztult", "Lepusztult", "Lepusztult"
            };
            int[,] aktuális = new int[,]
            {
                {1000 , 4400 , 660000},
                {0 , 3000 , 800000},
                {0 , 5000 , 300000}
            };
            ulong[] pénzek = new ulong[]
            {
                20040000000 , 20000000000 , 20000000000
            };
            for (int i = 0; i < 3; i++)
            {
                pont = városvezetés.Újév(pont, évek[i, 0], évek[i, 1], évek[i, 2]);
                Assert.That(városvezetés.városÉvei[i].állapot.ToString(), Is.EqualTo(eredmények[i]));
                Assert.That(városvezetés.városÉvei[i].tervezett[0], Is.EqualTo(évek[i, 0]));
                Assert.That(városvezetés.városÉvei[i].tervezett[1], Is.EqualTo(évek[i, 1]));
                Assert.That(városvezetés.városÉvei[i].tervezett[2], Is.EqualTo(évek[i, 2]));
                Assert.That(városvezetés.városÉvei[i].aktuális[0], Is.EqualTo(aktuális[i, 0]));
                Assert.That(városvezetés.városÉvei[i].aktuális[1], Is.EqualTo(aktuális[i, 1]));
                Assert.That(városvezetés.városÉvei[i].aktuális[2], Is.EqualTo(aktuális[i, 2]));
                Assert.That(városvezetés.városÉvei[i].bevétel, Is.EqualTo((nint)pénzek[i]));
            }
        }

        [Test]
        public void LepusztultKezdő()
        {
            int pont = 30;
            int[,] évek = new int[,]
            {
                {1000 , 4000 , 6000},
                {2000 , 3000 , 8000},
                {6500 , 5000 , 3000}
            };
            string[] eredmények = new string[]
            {
                "Lepusztult", "Lepusztult", "Lepusztult"
            };
            int[,] aktuális = new int[,]
            {
                {0 , 4000 , 6000},
                {0 , 3000 , 8000},
                {0 , 5000 , 3000}
            };
            ulong[] pénzek = new ulong[]
            {
                1000000000 , 1100000000 , 800000000
            };
            for (int i = 0; i < 3; i++)
            {
                pont = városvezetés.Újév(pont, évek[i, 0], évek[i, 1], évek[i, 2]);
                Assert.That(városvezetés.városÉvei[i].állapot.ToString(), Is.EqualTo(eredmények[i]));
                Assert.That(városvezetés.városÉvei[i].tervezett[0], Is.EqualTo(évek[i, 0]));
                Assert.That(városvezetés.városÉvei[i].tervezett[1], Is.EqualTo(évek[i, 1]));
                Assert.That(városvezetés.városÉvei[i].tervezett[2], Is.EqualTo(évek[i, 2]));
                Assert.That(városvezetés.városÉvei[i].aktuális[0], Is.EqualTo(aktuális[i, 0]));
                Assert.That(városvezetés.városÉvei[i].aktuális[1], Is.EqualTo(aktuális[i, 1]));
                Assert.That(városvezetés.városÉvei[i].aktuális[2], Is.EqualTo(aktuális[i, 2]));
                Assert.That(városvezetés.városÉvei[i].bevétel, Is.EqualTo((nint)pénzek[i]));
            }
        }

        [Test]
        public void JóKezdő()
        {
            int pont = 70;
            int[,] évek = new int[,]
            {
                {1000 , 4000 , 6000},
                {2000 , 3000 , 8000},
                {6500 , 5000 , 3000}
            };
            string[] eredmények = new string[]
            {
                "Lepusztult", "Lepusztult", "Lepusztult"
            };
            int[,] aktuális = new int[,]
            {
                {1200 , 5200 , 6000},
                {0 , 3000 , 8000},
                {0 , 5000 , 3000}
            };
            ulong[] pénzek = new ulong[]
            {
                1240000000 , 1100000000 , 800000000
            };
            for (int i = 0; i < 3; i++)
            {
                pont = városvezetés.Újév(pont, évek[i, 0], évek[i, 1], évek[i, 2]);
                Assert.That(városvezetés.városÉvei[i].állapot.ToString(), Is.EqualTo(eredmények[i]));
                Assert.That(városvezetés.városÉvei[i].tervezett[0], Is.EqualTo(évek[i, 0]));
                Assert.That(városvezetés.városÉvei[i].tervezett[1], Is.EqualTo(évek[i, 1]));
                Assert.That(városvezetés.városÉvei[i].tervezett[2], Is.EqualTo(évek[i, 2]));
                Assert.That(városvezetés.városÉvei[i].aktuális[0], Is.EqualTo(aktuális[i, 0]));
                Assert.That(városvezetés.városÉvei[i].aktuális[1], Is.EqualTo(aktuális[i, 1]));
                Assert.That(városvezetés.városÉvei[i].aktuális[2], Is.EqualTo(aktuális[i, 2]));
                Assert.That(városvezetés.városÉvei[i].bevétel, Is.EqualTo((nint)pénzek[i]));
            }
        }

    }
}