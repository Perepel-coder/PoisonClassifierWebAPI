using PoisonClassifierWebAPI.Server.Interfaces;
using PoisonClassifierWebAPI.Server.Models;

namespace PoisonClassifierWebAPI.Server.Repositories
{
    public class RepositoriesWork
    {
        #region Repository
        private readonly IRepository<Substance> dbS;
        private IRepository<SubstanceClass> dbSC;
        private IRepository<IndustrialVenom> dbIV;
        private IRepository<MedicalVenom> dbMV;
        private IRepository<Organ> dbOrgan;
        private IRepository<Models.Path> dbP;
        private IRepository<Origion> dbOrigin;
        private IRepository<AggregateState> dbAS;
        private IRepository<DegreeToxicity> dbDT;
        private IRepository<NatureImpact> dbNI;
        private IRepository<DegreeImpact> dbDI;
        private IRepository<Symptom> dbSymptom;
        #endregion

        #region конструктор
        public RepositoriesWork(ApplicationDBContext db)
        {
            dbS = new SQLSubstancRepository(db);
            dbSC = new SQLSubstanceClassesRepositories(db);
            dbIV = new SQLIndustrialVenomsRepositories(db);
            dbMV = new SQLMedicalVenomsRepositories(db);
            dbOrgan = new SQLOrgansReposotories(db);
            dbP = new SQLPathsRepository(db);
            dbOrigin = new SQLOrigionsReposotories(db);
            dbAS = new SQLAggregateStatesRepositories(db);
            dbDT = new SQLDegreeToxicitiesRepositories(db);
            dbNI = new SQLNatureImpactsRepositories(db);
            dbDI = new SQLDegreeImpactsRepositories(db);
            dbSymptom = new SQLSymptomsRepositories(db);
        }
        #endregion

        public async Task<IEnumerable<SubstancesOutput>> GetTableSubClasses()
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<SubstancesOutput> res = new();

                foreach (var el in dbS.GetList())
                {
                    res.Add(
                        new SubstancesOutput
                        {
                            Id = el.Id,
                            Name = el.Name,
                            MainClass = el.SubstanceClass.MainClass,
                            Chapter = el.SubstanceClass.Chapter,
                            SubGroup = el.SubstanceClass.SubGroup,
                            Group = el.SubstanceClass.Group,
                            IVenomId = el.IVenom.Id,
                            MVenomId = el.MVenom.Id
                        });
                }
                return res;
            });
            return await swc;
        }
        public async Task<SubstancesOutput> GetSubClass(int id)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                Substance el = dbS.GetElement(id);
                return new SubstancesOutput
                {
                    Id = el.Id,
                    Name = el.Name,
                    MainClass = el.SubstanceClass.MainClass,
                    Chapter = el.SubstanceClass.Chapter,
                    SubGroup = el.SubstanceClass.SubGroup,
                    Group = el.SubstanceClass.Group,
                    IVenomId = el.IVenom.Id,
                    MVenomId = el.MVenom.Id
                };
            });
            return await swc;
        }
        public async Task<IndustrialVenomOutput> GetIndustrialVenom(int id)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                IndustrialVenom el = dbIV.GetElement(id);

                return new IndustrialVenomOutput
                {
                    Id = el.Id,
                    DToxicityClass1 = el.DToxicity.Class1,
                    DToxicityClass2 = el.DToxicity.Class2,
                    DToxicityClass3 = el.DToxicity.Class3,
                    DToxicityClass4 = el.DToxicity.Class4,
                    NatureImpactGroupName = el.NatureImpact.GroupName,
                    NatureImpactGroupDescription = el.NatureImpact.GroupDescription,
                    NatureImpactGroupNameSG = el.NatureImpact.GroupNameSG,
                    DegreeImpactClass = el.DegreeImpact.Class,
                    DegreeImpactComment = el.DegreeImpact.Comment,
                    Paths = el.Paths.Select(el => el.Id).ToArray(),
                    Symptoms = el.Symptoms.Select(el => el.Id).ToArray()

                };
            });
            return await swc;
        }
        public async Task<MedicalVenomOutput> GetMedicalVenom(int id)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                MedicalVenom el = dbMV.GetElement(id);

                return new MedicalVenomOutput
                {
                    Id = el.Id,
                    OrigionGroup = el.Origion.Group,
                    OrigionSubGroup = el.Origion.SubGroup,
                    NatureImpactGroupName = el.NatureImpact.GroupName,
                    NatureImpactGroupDescription = el.NatureImpact.GroupDescription,
                    NatureImpactGroupNameSG = el.NatureImpact.GroupNameSG,
                    AggregateState = el.AggregateState.State
                };
            });
            return await swc;
        }

        public async Task<IEnumerable<SubstancesOutput>> GetSearch(string name){
            var swc = Task.Factory.StartNew(() =>
            {
                List<SubstancesOutput> substancesOutputs = new();
                var substances = dbS.GetList().Where(x => x.Name.ToLower().IndexOf(name.ToLower()) >= 0).Select(el => el).ToList();
                foreach (var el in substances)
                {
                    substancesOutputs.Add(new SubstancesOutput
                    {
                        Id = el.Id,
                        Name = el.Name,
                        MainClass = el.SubstanceClass.MainClass,
                        Chapter = el.SubstanceClass.Chapter,
                        SubGroup = el.SubstanceClass.SubGroup,
                        Group = el.SubstanceClass.Group,
                        IVenomId = el.IVenom.Id,
                        MVenomId = el.MVenom.Id
                    });
                }
                return substancesOutputs;
            });
            return await swc;
        }

        #region Classifier
        public async Task<IEnumerable<SubstanceClassOutput>> GetListSubstanceClass()
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<SubstanceClassOutput> res = new();

                var sc = dbSC.GetList();

                foreach (var el in sc)
                {
                    res.Add(
                        new SubstanceClassOutput
                        {
                            Id = el.Id,
                            MainClass = el.MainClass,
                            Chapter = el.Chapter,
                            Group = el.Group,
                            SubGroup = el.SubGroup
                        });
                }
                return res;
            });
            return await swc;
        }
        public async Task<IEnumerable<SubstanceClassOutput>> GetListSubstanceClassForClass(string mainclass)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<SubstanceClassOutput> res = new();

                var sc = dbSC.GetList()
                .Where(x => x.MainClass == mainclass)
                .Select(el => el);

                foreach (var el in sc)
                {
                    res.Add(
                        new SubstanceClassOutput
                        {
                            Id = el.Id,
                            MainClass = el.MainClass,
                            Chapter = el.Chapter,
                            Group = el.Group,
                            SubGroup = el.SubGroup
                        });
                }
                return res;
            });
            return await swc;
        }
        public async Task<IEnumerable<SubstanceClassOutput>> GetListSubstanceClassForChapter(string[] data)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<SubstanceClassOutput> res = new();

                var sc = dbSC.GetList()
                .Where(x => x.MainClass == data[0] && x.Chapter == data[1])
                .Select(el => el);

                foreach (var el in sc)
                {
                    res.Add(
                        new SubstanceClassOutput
                        {
                            Id = el.Id,
                            MainClass = el.MainClass,
                            Chapter = el.Chapter,
                            Group = el.Group,
                            SubGroup = el.SubGroup
                        });
                }
                return res;
            });
            return await swc;
        }
        public async Task<IEnumerable<SubstanceClassOutput>> GetListSubstanceClassForGroup(string[] data)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<SubstanceClassOutput> res = new();

                var sc = dbSC.GetList()
                .Where(x => x.MainClass == data[0] && x.Chapter == data[1] && x.Group == data[2])
                .Select(el => el);

                foreach (var el in sc)
                {
                    res.Add(
                        new SubstanceClassOutput
                        {
                            Id = el.Id,
                            MainClass = el.MainClass,
                            Chapter = el.Chapter,
                            Group = el.Group,
                            SubGroup = el.SubGroup
                        });
                }
                return res;
            });
            return await swc;
        }

        public async Task<IEnumerable<NatureImpactOutput>> GetListNatureImpact()
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<NatureImpactOutput> res = new();

                var ni = dbNI.GetList();

                foreach (var el in ni)
                {
                    res.Add(
                        new NatureImpactOutput
                        {
                            Id = el.Id,
                            GroupName = el.GroupName,
                            GroupDescription = el.GroupDescription,
                            GroupNameSG = el.GroupNameSG
                        });
                }
                return res;
            });
            return await swc;
        }
        public async Task<IEnumerable<NatureImpactOutput>> GetListNatureImpactForName(string name)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<NatureImpactOutput> res = new();

                var ni = dbNI.GetList().Where(x => x.GroupName == name).Select(el => el);

                foreach (var el in ni)
                {
                    res.Add(
                        new NatureImpactOutput
                        {
                            Id = el.Id,
                            GroupName = el.GroupName,
                            GroupDescription = el.GroupDescription,
                            GroupNameSG = el.GroupNameSG
                        });
                }
                return res;
            });
            return await swc;
        }
        public async Task<IEnumerable<NatureImpactOutput>> GetListNatureImpactForDescription(string[] data)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<NatureImpactOutput> res = new();

                var ni = dbNI.GetList()
                .Where(x => x.GroupName == data[0] && x.GroupDescription == data[1])
                .Select(el => el);

                foreach (var el in ni)
                {
                    res.Add(
                        new NatureImpactOutput
                        {
                            Id = el.Id,
                            GroupName = el.GroupName,
                            GroupDescription = el.GroupDescription,
                            GroupNameSG = el.GroupNameSG
                        });
                }
                return res;
            });
            return await swc;
        }

        public async Task<IEnumerable<DegreeImpactOutput>> GetListDegreeImpact()
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<DegreeImpactOutput> res = new();

                var ni = dbDI.GetList();

                foreach (var el in ni)
                {
                    res.Add(
                        new DegreeImpactOutput
                        {
                            Id = el.Id,
                            Class = el.Class,
                            Comment = el.Comment
                        });
                }
                return res;
            });
            return await swc;
        }
        public async Task<IEnumerable<DegreeImpactOutput>> GetListDegreeImpactForClass(string myclass)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<DegreeImpactOutput> res = new();

                var ni = dbDI.GetList().Where(x => x.Class == myclass).Select(el => el);

                foreach (var el in ni)
                {
                    res.Add(
                        new DegreeImpactOutput
                        {
                            Id = el.Id,
                            Class = el.Class,
                            Comment = el.Comment
                        });
                }
                return res;
            });
            return await swc;
        }

        public async Task<IEnumerable<OrigionOutput>> GetListOrigion()
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<OrigionOutput> res = new();

                var origions = dbOrigin.GetList();

                foreach (var el in origions)
                {
                    res.Add(
                        new OrigionOutput
                        {
                            Id = el.Id,
                            Group = el.Group,
                            SubGroup = el.SubGroup
                        });
                }
                return res;
            });
            return await swc;
        }
        public async Task<IEnumerable<OrigionOutput>> GetListOrigionForGroup(string group)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<OrigionOutput> res = new();

                var origions = dbOrigin.GetList().Where(x => x.Group == group).Select(el => el);

                foreach (var el in origions)
                {
                    res.Add(
                        new OrigionOutput
                        {
                            Id = el.Id,
                            Group = el.Group,
                            SubGroup = el.SubGroup
                        });
                }
                return res;
            });
            return await swc;
        }

        public async Task<IEnumerable<string?>> GetListAggregateState()
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<string?> res = new();

                var ast = dbAS.GetList();

                foreach (var el in ast) { res.Add(el.State); }

                return res;
            });
            return await swc;
        }
        public async Task<IEnumerable<AggregateStateOutput?>> GetAggregateStates()
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<AggregateStateOutput?> res = new();

                var ast = dbAS.GetList();

                foreach (var el in ast) { 
                    res.Add(
                        new AggregateStateOutput { 
                            Id = el.Id, 
                            State = el.State
                        }); 
                }

                return res;
            });
            return await swc;
        }

        public async Task<IEnumerable<PathOutput?>> GetListPath()
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<PathOutput> res = new();

                foreach (var el in dbP.GetList())
                {
                    string path = "->";
                    foreach (var organ in el.Organs) { path += (organ.Name + "->"); }
                    res.Add(
                        new PathOutput
                        {
                            Id = el.Id,
                            Name = el.Name,
                            Organs = path,
                            Output = el.Output
                        });
                }
                return res;
            });
            return await swc;
        }
        public async Task<List<int>> GetOrganOfPath(int idpath)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<int> res = new();

                var organs = dbP.GetList().Where(x => x.Id == idpath).Select(el => el.Organs).Single();

                foreach (var el in organs)
                {
                    res.Add(el.Id);
                }
                return res;
            });
            return await swc;
        }

        public async Task<IEnumerable<SymptomOutput?>> GetListSymptom()
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<SymptomOutput> res = new();

                foreach (var el in dbSymptom.GetList())
                {
                    res.Add(new SymptomOutput { Id = el.Id, Name = el.Name });
                }
                return res;
            });
            return await swc;
        }
        public async Task<IEnumerable<OrganOutput?>> GetListOrgan()
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<OrganOutput> res = new();

                foreach (var el in  dbOrgan.GetList())
                {
                    res.Add(new OrganOutput { Id = el.Id, Name = el.Name });
                }
                return res;
            });
            return await swc;
        }

        public async Task<IEnumerable<PathOutput?>> GetListPath(int[] pathIdarray)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<PathOutput> res = new();

                foreach (var el in dbP.GetList())
                {
                    foreach (var id in pathIdarray)
                    {
                        if (el.Id == id)
                        {
                            string path = "->";
                            foreach (var organ in el.Organs) { path += (organ.Name + "->"); }
                            res.Add(
                                new PathOutput
                                {
                                    Id = el.Id,
                                    Name = el.Name,
                                    Organs = path,
                                    Output = el.Output
                                });
                            break;
                        }
                    }
                }
                return res;
            });
            return await swc;
        }
        public async Task<IEnumerable<SymptomOutput?>> GetListSymptom(int[] symptomIdarray)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<SymptomOutput> res = new();

                foreach (var el in dbSymptom.GetList())
                {
                    foreach (var id in symptomIdarray)
                    {
                        if (el.Id == id)
                        {
                            res.Add(new SymptomOutput { Id = el.Id, Name = el.Name });
                            break;
                        }
                    }
                }
                return res;
            });
            return await swc;
        }


        #endregion

        #region Save Update Delete
        public async Task<bool> SaveSubstance(SaveData saveData)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    Substance substance = new()
                    {
                        Name = saveData.Classub[0],
                        SubstanceClass = dbSC.GetList()
                        .Where(x =>
                        x.MainClass == saveData.Classub[1] &&
                        x.Chapter == saveData.Classub[2] &&
                        x.Group == saveData.Classub[3] &&
                        x.SubGroup == saveData.Classub[4])
                        .Select(el => el).Single()
                    };
                    dbS.Create(substance);

                    IndustrialVenom industrialVenom = new()
                    {
                        Substance = substance,
                        NatureImpact = dbNI.GetList()
                        .Where(x =>
                        x.GroupName == saveData.NatureImpact[0] &&
                        x.GroupDescription == saveData.NatureImpact[1] &&
                        x.GroupNameSG == saveData.NatureImpact[2])
                        .Select(el => el).Single(),
                        DegreeImpact = dbDI.GetList()
                        .Where(x =>
                        x.Class == saveData.DegreeImpact[0] &&
                        x.Comment == saveData.DegreeImpact[1])
                        .Select(el => el).Single()
                    };
                    dbIV.Create(industrialVenom);

                    DegreeToxicity degreeToxicity = new()
                    {
                        Class1 = saveData.DegreeToxity[0],
                        Class2 = saveData.DegreeToxity[1],
                        Class3 = saveData.DegreeToxity[2],
                        Class4 = saveData.DegreeToxity[3],
                        IndustrialVenom = industrialVenom
                    };
                    dbDT.Create(degreeToxicity);

                    MedicalVenom medicalVenom = new()
                    {
                        Substance = substance,
                        Origion = dbOrigin.GetList()
                        .Where(x =>
                        x.Group == saveData.Origion[0] &&
                        x.SubGroup == saveData.Origion[1])
                        .Select(el => el).Single(),
                        AggregateState = dbAS.GetList()
                        .Where(x =>
                        x.State == saveData.AggregateState)
                        .Select(el => el).Single(),
                        NatureImpact = dbNI.GetList()
                        .Where(x =>
                        x.GroupName == saveData.NatureImpact[0] &&
                        x.GroupDescription == saveData.NatureImpact[1] &&
                        x.GroupNameSG == saveData.NatureImpact[2])
                        .Select(el => el).Single()
                    };
                    dbMV.Create(medicalVenom);

                    foreach (int id in saveData.Paths)
                    {
                        industrialVenom.Paths.Add(dbP
                            .GetList()
                            .Where(x => x.Id == id)
                            .Select(el => el)
                            .Single());
                    }
                    foreach (int id in saveData.Symptoms)
                    {
                        industrialVenom.Symptoms.Add(dbSymptom
                            .GetList()
                            .Where(x => x.Id == id)
                            .Select(el => el)
                            .Single());
                    }
                    foreach (int id in saveData.Symptoms)
                    {
                        medicalVenom.Symptoms.Add(dbSymptom
                            .GetList()
                            .Where(x => x.Id == id)
                            .Select(el => el)
                            .Single());
                    }

                    dbS.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }
        public async Task<bool> ChangeSubstance(SaveData saveData)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    Substance substance = dbS.GetElement(saveData.Id);
                    substance.Name = saveData.Classub[0];
                    substance.SubstanceClass = dbSC.GetList()
                        .Where(x =>
                        x.MainClass == saveData.Classub[1] &&
                        x.Chapter == saveData.Classub[2] &&
                        x.Group == saveData.Classub[3] &&
                        x.SubGroup == saveData.Classub[4])
                        .Select(el => el).Single();
                    dbS.Update(substance);

                    IndustrialVenom industrialVenom = dbIV.GetElement(substance.IVenom.Id);
                    industrialVenom.NatureImpact = dbNI.GetList()
                        .Where(x =>
                        x.GroupName == saveData.NatureImpact[0] &&
                        x.GroupDescription == saveData.NatureImpact[1] &&
                        x.GroupNameSG == saveData.NatureImpact[2])
                        .Select(el => el).Single();
                    industrialVenom.DegreeImpact = dbDI.GetList()
                        .Where(x =>
                        x.Class == saveData.DegreeImpact[0] &&
                        x.Comment == saveData.DegreeImpact[1])
                        .Select(el => el).Single();
                    dbIV.Update(industrialVenom);

                    DegreeToxicity degreeToxicity = dbDT
                    .GetList()
                    .Where(x => x.IndustrialVenomId == industrialVenom.Id)
                    .Select(el => el).Single();
                    degreeToxicity.Class1 = saveData.DegreeToxity[0];
                    degreeToxicity.Class2 = saveData.DegreeToxity[1];
                    degreeToxicity.Class3 = saveData.DegreeToxity[2];
                    degreeToxicity.Class4 = saveData.DegreeToxity[3];
                    dbDT.Update(degreeToxicity);

                    MedicalVenom medicalVenom = dbMV.GetElement(substance.MVenom.Id);
                    medicalVenom.Origion = dbOrigin.GetList()
                        .Where(x =>
                        x.Group == saveData.Origion[0] &&
                        x.SubGroup == saveData.Origion[1])
                        .Select(el => el).Single();
                    medicalVenom.AggregateState = dbAS.GetList()
                        .Where(x =>
                        x.State == saveData.AggregateState)
                        .Select(el => el).Single();
                    medicalVenom.NatureImpact = dbNI.GetList()
                        .Where(x =>
                        x.GroupName == saveData.NatureImpact[0] &&
                        x.GroupDescription == saveData.NatureImpact[1] &&
                        x.GroupNameSG == saveData.NatureImpact[2])
                        .Select(el => el).Single();
                    dbMV.Update(medicalVenom);

                    industrialVenom.Paths.Clear();
                    foreach (int id in saveData.Paths)
                    {
                        industrialVenom.Paths.Add(dbP
                            .GetList()
                            .Where(x => x.Id == id)
                            .Select(el => el)
                            .Single());
                    }
                    industrialVenom.Symptoms.Clear();
                    foreach (int id in saveData.Symptoms)
                    {
                        industrialVenom.Symptoms.Add(dbSymptom
                            .GetList()
                            .Where(x => x.Id == id)
                            .Select(el => el)
                            .Single());
                    }
                    medicalVenom.Symptoms.Clear();
                    foreach (int id in saveData.Symptoms)
                    {
                        medicalVenom.Symptoms.Add(dbSymptom
                            .GetList()
                            .Where(x => x.Id == id)
                            .Select(el => el)
                            .Single());
                    }

                    dbS.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }
        public async Task<bool> DeleteSubstance(int id)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try { dbS.Delete(id); dbS.Save(); return true; }
                catch { return false; }

            });
            return await swc;
        }

        public async Task<bool> SaveSubstanceClass(SaveData saveData)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    if(int.Parse(saveData.Classub[0]) == -1)
                    {
                        SubstanceClass substanceClass = new()
                        {
                            MainClass = saveData.Classub[1],
                            Chapter = saveData.Classub[2],
                            Group = saveData.Classub[3],
                            SubGroup = saveData.Classub[4]
                        };
                        dbSC.Create(substanceClass);
                    }
                    else
                    {
                        int subClassId = int.Parse(saveData.Classub[0]);
                        SubstanceClass substanceClass = dbSC.GetList()
                        .Where(x => x.Id == subClassId).Select(el => el).Single();
                        substanceClass.MainClass = saveData.Classub[1];
                        substanceClass.Chapter = saveData.Classub[2];
                        substanceClass.Group = saveData.Classub[3];
                        substanceClass.SubGroup = saveData.Classub[4];
                        dbSC.Update(substanceClass);
                    }
                    dbSC.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }
        public async Task<bool> DeleteSubstanceClass(int id)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try { 
                    dbSC.Delete(id); 
                    dbSC.Save(); 
                    return true; 
                }
                catch { return false; }

            });
            return await swc;
        }

        public async Task<bool> SaveNatureImpact(SaveData saveData)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    if (int.Parse(saveData.NatureImpact[0]) == -1)
                    {
                        NatureImpact natureImpact = new()
                        {
                            GroupName = saveData.NatureImpact[1],
                            GroupDescription = saveData.NatureImpact[2],
                            GroupNameSG = saveData.NatureImpact[3],
                        };
                        dbNI.Create(natureImpact);
                    }
                    else
                    {
                        int natureImpactId = int.Parse(saveData.NatureImpact[0]);
                        NatureImpact natureImpact = dbNI.GetList()
                        .Where(x => x.Id == natureImpactId).Select(el => el).Single();
                        natureImpact.GroupName = saveData.NatureImpact[1];
                        natureImpact.GroupDescription = saveData.NatureImpact[2];
                        natureImpact.GroupNameSG = saveData.NatureImpact[3];
                        dbNI.Update(natureImpact);
                    }
                    dbNI.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }
        public async Task<bool> DeleteNatureImpact(int id)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    dbNI.Delete(id);
                    dbNI.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }

        public async Task<bool> SaveDegreeImpact(SaveData saveData)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    if (int.Parse(saveData.DegreeImpact[0]) == -1)
                    {
                        DegreeImpact degreeImpact = new()
                        {
                            Class = saveData.DegreeImpact[1],
                            Comment = saveData.DegreeImpact[2]
                        };
                        dbDI.Create(degreeImpact);
                    }
                    else
                    {
                        int degreeImpactId = int.Parse(saveData.DegreeImpact[0]);
                        DegreeImpact degreeImpact = dbDI.GetList()
                        .Where(x => x.Id == degreeImpactId).Select(el => el).Single();
                        degreeImpact.Class = saveData.DegreeImpact[1];
                        degreeImpact.Comment = saveData.DegreeImpact[2];
                        dbDI.Update(degreeImpact);
                    }
                    dbDI.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }
        public async Task<bool> DeleteDegreeImpact(int id)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    dbDI.Delete(id);
                    dbDI.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }

        public async Task<bool> SaveOrigion(SaveData saveData)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    if (int.Parse(saveData.Origion[0]) == -1)
                    {
                        Origion origion = new()
                        {
                            Group = saveData.Origion[1],
                            SubGroup = saveData.Origion[2]
                        };
                        dbOrigin.Create(origion);
                    }
                    else
                    {
                        int origionId = int.Parse(saveData.Origion[0]);
                        Origion origion = dbOrigin.GetList()
                        .Where(x => x.Id == origionId).Select(el => el).Single();
                        origion.Group = saveData.Origion[1];
                        origion.SubGroup = saveData.Origion[2];
                        dbOrigin.Update(origion);
                    }
                    dbOrigin.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }
        public async Task<bool> DeleteOrigion(int id)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    dbOrigin.Delete(id);
                    dbOrigin.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }

        public async Task<bool> SaveAggregateState(SaveData saveData)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    if (saveData.Id == -1)
                    {
                        AggregateState aggregateState = new()
                        {
                            State = saveData.AggregateState
                        };
                        dbAS.Create(aggregateState);
                    }
                    else
                    {
                        AggregateState aggregateState = dbAS.GetList()
                        .Where(x => x.Id == saveData.Id).Select(el => el).Single();
                        aggregateState.State = saveData.AggregateState;
                        dbAS.Update(aggregateState);
                    }
                    dbAS.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }
        public async Task<bool> DeleteAggregateState(int id)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    dbAS.Delete(id);
                    dbAS.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }

        public async Task<bool> SaveSymptom(string[] data)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    if (int.Parse(data[0]) == -1)
                    {
                        Symptom symptom = new()
                        {
                            Name = data[1]
                        };
                        dbSymptom.Create(symptom);
                    }
                    else
                    {
                        int symptomId = int.Parse(data[0]);
                        Symptom symptom = dbSymptom.GetList()
                        .Where(x => x.Id == symptomId).Select(el => el).Single();
                        symptom.Name = data[1];
                        dbSymptom.Update(symptom);
                    }
                    dbSymptom.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }
        public async Task<bool> DeleteSymptom(int id)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    dbSymptom.Delete(id);
                    dbSymptom.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }

        public async Task<bool> SaveOrgan(string[] data)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    if (int.Parse(data[0]) == -1)
                    {
                        Organ organ = new()
                        {
                            Name = data[1]
                        };
                        dbOrgan.Create(organ);
                    }
                    else
                    {
                        int organId = int.Parse(data[0]);
                        Organ organ = dbOrgan.GetList()
                        .Where(x => x.Id == organId).Select(el => el).Single();
                        organ.Name = data[1];
                        dbOrgan.Update(organ);
                    }
                    dbOrgan.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }
        public async Task<bool> DeleteOrgan(int id)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    dbOrgan.Delete(id);
                    dbOrgan.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }

        public async Task<bool> SavePath(SavePath path)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    if (path.Id == -1)
                    {
                        Models.Path pathdb = new()
                        {
                            Name = path.Name,
                            Output = path.Output
                        };
                        dbP.Create(pathdb);
                        List<Organ> organs = dbOrgan.GetList().ToList();
                        pathdb.Organs = new();
                        foreach (var organId in path.Organs)
                        {
                            pathdb.Organs.Add(
                                organs
                                .Where(x => x.Id == organId)
                                .Select(el => el).Single());
                        }
                    }
                    else
                    {
                        Models.Path pathdb = dbP.GetList()
                        .Where(x => x.Id == path.Id).Select(el => el).Single();
                        pathdb.Name = path.Name;
                        pathdb.Output = path.Output;
                        pathdb.Organs.Clear();
                        List<Organ> organs = dbOrgan.GetList().ToList();
                        foreach (var organId in path.Organs)
                        {
                            pathdb.Organs.Add(
                                organs
                                .Where(x => x.Id == organId)
                                .Select(el => el).Single());
                        }
                        dbP.Update(pathdb);
                    }
                    dbOrgan.Save();
                    return true;
                }
                catch { return false; }
            });
            return await swc;
        }
        public async Task<bool> DeletePath(int id)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                try
                {
                    dbP.Delete(id);
                    dbP.Save();
                    return true;
                }
                catch { return false; }

            });
            return await swc;
        }
        #endregion

        #region Search

        public async Task<IEnumerable<SubstancesOutput>> GetChemicalClassifierExact(string[] data)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<SubstancesOutput> res = new();

                var dbSubstance = dbS.GetList()
                .Where(x =>
                x.SubstanceClass.MainClass == data[0] &&
                x.SubstanceClass.Chapter == data[1] &&
                x.SubstanceClass.Group == data[2] &&
                x.SubstanceClass.SubGroup == data[3])
                .Select(el => el);
                foreach (var el in dbSubstance)
                {
                    res.Add(
                        new SubstancesOutput
                        {
                            Id = el.Id,
                            Name = el.Name,
                            MainClass = el.SubstanceClass.MainClass,
                            Chapter = el.SubstanceClass.Chapter,
                            SubGroup = el.SubstanceClass.SubGroup,
                            Group = el.SubstanceClass.Group,
                            IVenomId = el.IVenom.Id,
                            MVenomId = el.MVenom.Id
                        });
                }
                return res;
            });
            return await swc;
        }
        public async Task<IEnumerable<SubstancesOutput>> GetChemicalClassifierLax(string[] data)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<SubstancesOutput> res = new();

                var dbSubstance = dbS.GetList()
                .Where(x =>
                x.SubstanceClass.MainClass == data[0] ||
                x.SubstanceClass.Chapter == data[1] ||
                x.SubstanceClass.Group == data[2] ||
                x.SubstanceClass.SubGroup == data[3])
                .Select(el => el);
                foreach (var el in dbSubstance)
                {
                    res.Add(
                        new SubstancesOutput
                        {
                            Id = el.Id,
                            Name = el.Name,
                            MainClass = el.SubstanceClass.MainClass,
                            Chapter = el.SubstanceClass.Chapter,
                            SubGroup = el.SubstanceClass.SubGroup,
                            Group = el.SubstanceClass.Group,
                            IVenomId = el.IVenom.Id,
                            MVenomId = el.MVenom.Id
                        });
                }
                return res;
            });
            return await swc;
        }

        public async Task<IEnumerable<SubstancesOutput>> GetClassifierSymptomsExact(POSTClassifierSymptoms data)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<SubstancesOutput> res = new();

                dbIV.GetList(); dbMV.GetList();

                var substances = dbS.GetList()
                .Where(x =>
                x.IVenom.NatureImpact.GroupName == data.NatureImpactAndOrigion[0] &&
                x.IVenom.NatureImpact.GroupDescription == data.NatureImpactAndOrigion[1] &&
                x.IVenom.NatureImpact.GroupNameSG == data.NatureImpactAndOrigion[2] &&
                x.MVenom.Origion.Group == data.NatureImpactAndOrigion[3] &&
                x.MVenom.Origion.SubGroup == data.NatureImpactAndOrigion[4])
                .Select(el => el);
                List<Substance> dbSubstance = new();
                foreach (var sub in substances)
                {
                    int count = 0;
                    foreach(var symptom in sub.MVenom.Symptoms)
                    {
                        if (data.Symptoms.Contains(symptom.Id)) { count++; }
                    }
                    if (count == data.Symptoms.Length) { dbSubstance.Add(sub); }
                }
                foreach (var el in dbSubstance)
                {
                    res.Add(
                        new SubstancesOutput
                        {
                            Id = el.Id,
                            Name = el.Name,
                            MainClass = el.SubstanceClass.MainClass,
                            Chapter = el.SubstanceClass.Chapter,
                            SubGroup = el.SubstanceClass.SubGroup,
                            Group = el.SubstanceClass.Group,
                            IVenomId = el.IVenom.Id,
                            MVenomId = el.MVenom.Id
                        });
                }
                return res;
            });
            return await swc;
        }
        public async Task<IEnumerable<SubstancesOutput>> GetClassifierSymptomsLax(POSTClassifierSymptoms data)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                List<SubstancesOutput> res = new();

                dbIV.GetList(); dbMV.GetList();

                var dbSubstance = dbS.GetList()
                .Where(x =>
                 x.IVenom.NatureImpact.GroupName == data.NatureImpactAndOrigion[0] ||
                 x.IVenom.NatureImpact.GroupDescription == data.NatureImpactAndOrigion[1] ||
                 x.IVenom.NatureImpact.GroupNameSG == data.NatureImpactAndOrigion[2] || 
                 x.MVenom.Origion.Group == data.NatureImpactAndOrigion[3] || 
                 x.MVenom.Origion.SubGroup == data.NatureImpactAndOrigion[4])
                 .Select(el => el).ToList();

                foreach (var sub in dbS.GetList())
                {
                    foreach (var symptom in sub.MVenom.Symptoms)
                    {
                        if (data.Symptoms.Contains(symptom.Id) && !dbSubstance.Contains(sub)) 
                        { dbSubstance.Add(sub); break; }
                    }
                }
                foreach (var el in dbSubstance)
                {
                    res.Add(
                        new SubstancesOutput
                        {
                            Id = el.Id,
                            Name = el.Name,
                            MainClass = el.SubstanceClass.MainClass,
                            Chapter = el.SubstanceClass.Chapter,
                            SubGroup = el.SubstanceClass.SubGroup,
                            Group = el.SubstanceClass.Group,
                            IVenomId = el.IVenom.Id,
                            MVenomId = el.MVenom.Id
                        });
                }
                return res;
            });
            return await swc;
        }

        public async Task<IEnumerable<SubstancesOutput>> GetToxicClassifierExact(string[] data)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                dbIV.GetList(); dbMV.GetList();
                List<SubstancesOutput> res = new();

                var dbSubstance = dbS.GetList()
                .Where(x =>
                x.IVenom.DegreeImpact.Class == data[0] &&
                x.IVenom.DegreeImpact.Comment == data[1] &&
                x.MVenom.AggregateState.State == data[2] &&
                x.IVenom.DToxicity.Class1 == data[3] &&
                x.IVenom.DToxicity.Class2 == data[4] &&
                x.IVenom.DToxicity.Class3 == data[5] &&
                x.IVenom.DToxicity.Class4 == data[6])
                .Select(el => el);
                foreach (var el in dbSubstance)
                {
                    res.Add(
                        new SubstancesOutput
                        {
                            Id = el.Id,
                            Name = el.Name,
                            MainClass = el.SubstanceClass.MainClass,
                            Chapter = el.SubstanceClass.Chapter,
                            SubGroup = el.SubstanceClass.SubGroup,
                            Group = el.SubstanceClass.Group,
                            IVenomId = el.IVenom.Id,
                            MVenomId = el.MVenom.Id
                        });
                }
                return res;
            });
            return await swc;
        }
        public async Task<IEnumerable<SubstancesOutput>> GetToxicClassifierLax(string[] data)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                dbIV.GetList(); dbMV.GetList();
                List<SubstancesOutput> res = new();

                var dbSubstance = dbS.GetList()
                .Where(x =>
                x.IVenom.DegreeImpact.Class == data[0] ||
                x.IVenom.DegreeImpact.Comment == data[1] ||
                x.MVenom.AggregateState.State == data[2] ||
                x.IVenom.DToxicity.Class1 == data[3] ||
                x.IVenom.DToxicity.Class2 == data[4] ||
                x.IVenom.DToxicity.Class3 == data[5] ||
                x.IVenom.DToxicity.Class4 == data[6])
                .Select(el => el);
                foreach (var el in dbSubstance)
                {
                    res.Add(
                        new SubstancesOutput
                        {
                            Id = el.Id,
                            Name = el.Name,
                            MainClass = el.SubstanceClass.MainClass,
                            Chapter = el.SubstanceClass.Chapter,
                            SubGroup = el.SubstanceClass.SubGroup,
                            Group = el.SubstanceClass.Group,
                            IVenomId = el.IVenom.Id,
                            MVenomId = el.MVenom.Id
                        });
                }
                return res;
            });
            return await swc;
        }

        public async Task<IEnumerable<SubstancesOutput>> GetPathClassifierExact(string[] data)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                dbS.GetList(); dbIV.GetList(); dbMV.GetList();
                List<SubstancesOutput> res = new();
                List<Models.Path> paths = dbP.GetList()
                .Where(x => x.Name == data[0] && x.Output == data[1]).Select(el => el).ToList();
                foreach(var path in paths)
                {
                    int count = 0;
                    foreach(var organ in path.Organs)
                    {
                        if (data.Contains(organ.Name)) { count++; }
                    }
                    if(count == data.Length - 2)
                    {
                        foreach(var iv in path.IndustrialVenoms)
                        {
                            res.Add(
                                new SubstancesOutput
                                {
                                    Id = iv.Substance.Id,
                                    Name = iv.Substance.Name,
                                    MainClass = iv.Substance.SubstanceClass.MainClass,
                                    Chapter = iv.Substance.SubstanceClass.Chapter,
                                    SubGroup = iv.Substance.SubstanceClass.SubGroup,
                                    Group = iv.Substance.SubstanceClass.Group,
                                    IVenomId = iv.Substance.IVenom.Id,
                                    MVenomId = iv.Substance.MVenom.Id
                                });
                        }
                    }
                }
               
                return res;
            });
            return await swc;
        }
        public async Task<IEnumerable<SubstancesOutput>> GetPathClassifierLax(string[] data)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                dbS.GetList(); dbIV.GetList(); dbMV.GetList();
                List<SubstancesOutput> res = new();
                List<Models.Path> paths = dbP.GetList()
                .Where(x => x.Name == data[0] || x.Output == data[1]).Select(el => el).ToList();
                foreach (var path in paths)
                {
                    foreach (var organ in path.Organs)
                    {
                        if (data.Contains(organ.Name)) 
                        {
                            foreach (var iv in path.IndustrialVenoms)
                            {
                                res.Add(
                                    new SubstancesOutput
                                    {
                                        Id = iv.Substance.Id,
                                        Name = iv.Substance.Name,
                                        MainClass = iv.Substance.SubstanceClass.MainClass,
                                        Chapter = iv.Substance.SubstanceClass.Chapter,
                                        SubGroup = iv.Substance.SubstanceClass.SubGroup,
                                        Group = iv.Substance.SubstanceClass.Group,
                                        IVenomId = iv.Substance.IVenom.Id,
                                        MVenomId = iv.Substance.MVenom.Id
                                    });
                            }
                            break;
                        }
                    }
                }
                return res;
            });
            return await swc;
        }
        #endregion

        #region autorization
        public async Task<bool> GetAutorization(string[] data)
        {
            var swc = Task.Factory.StartNew(() =>
            {
                using (FileStream fstream = File.OpenRead(@"Server\Models\autorizationData.txt"))
                {
                    // выделяем массив для считывания данных из файла
                    byte[] buffer = new byte[fstream.Length];
                    // считываем данные
                    fstream.Read(buffer, 0, buffer.Length);
                    // декодируем байты в строку
                    string[] textFromFile = System.Text.Encoding.Default.GetString(buffer).Split('\\');
                    if 
                    (
                        String.Compare(data[0], textFromFile[0]) == 0 && 
                        String.Compare(data[1], textFromFile[1]) == 0
                    ) 
                    { return true; }
                    return false;
                }
            });
            return await swc;
        }
        #endregion
    }
}
