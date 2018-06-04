using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NuDataDb.Repositories
{
    public class ToGenerate
    {
        public string TableName { get; set; }
        public string KeyField { get; set; }
        public bool isGuid { get; set; }
        public bool isLong { get; set; }
    }

    public class GenerateTheCode
    {
        List<ToGenerate> ToGen = new List<ToGenerate>
        {
            new ToGenerate
            {
                TableName = "Applications",
                isGuid = true,
                KeyField = "ApplicationId"
            },
            new ToGenerate
            {
                TableName = "AppLoginHistories",
                isGuid = false,
                isLong = false,
                KeyField = "HistoryId"
            },
            new ToGenerate
            {
                TableName = "AppSettings",
                isGuid = false,
                isLong = false,
                KeyField = "AppSettingId"
            },
            new ToGenerate
            {
                TableName = "AppUserSettings",
                isGuid = false,
                isLong = false,
                KeyField = "AppUserSettingId"
            },
            new ToGenerate
            {
                TableName = "BasalDeliveries",
                isGuid = false,
                isLong = false,
                KeyField = "BasalDeliveryId"
            },
            new ToGenerate
            {
                TableName = "BasalDeliveryData",
                isGuid = false,
                isLong = false,
                KeyField = "DataId"
            },
            new ToGenerate
            {
                TableName = "ProgramTimeSlots",
                isGuid = false,
                isLong = false,
                KeyField = "SlotId"
            },
            new ToGenerate
            {
                TableName = "BGTargets",
                isGuid = false,
                isLong = false,
                KeyField = "TargetId"
            },
            new ToGenerate
            {
                TableName = "BloodGlucoseReadings",
                isGuid = false,
                isLong = true,
                KeyField = "ReadingId"
            },
            new ToGenerate
            {
                TableName = "BolusCarbs",
                isGuid = false,
                isLong = false,
                KeyField = "CarbId"
            },
            new ToGenerate
            {
                TableName = "BolusDelivery",
                isGuid = false,
                isLong = false,
                KeyField = "BolusDeliveryId"
            },
            new ToGenerate
            {
                TableName = "BolusDeliveryData",
                isGuid = false,
                isLong = false,
                KeyField = "DataId"
            },
            new ToGenerate
            {
                TableName = "BolusProgramTimeSlots",
                isGuid = false,
                isLong = false,
                KeyField = "BolusSlotId"
            },
            new ToGenerate
            {
                TableName = "CareSettings",
                isGuid = false,
                isLong = false,
                KeyField = "CareSettingsId"
            },
            new ToGenerate
            {
                TableName = "CGMReminders",
                isGuid = false,
                isLong = false,
                KeyField = "ReminderId"
            },
            new ToGenerate
            {
                TableName = "CGMSessions",
                isGuid = true,
                isLong = false,
                KeyField = "CGMId"
            },
            new ToGenerate
            {
                TableName = "Checks",
                isGuid = false,
                isLong = false,
                KeyField = "CheckId"
            },
            new ToGenerate
            {
                TableName = "CheckStatus",
                isGuid = false,
                isLong = false,
                KeyField = "StatusId"
            },
            new ToGenerate
            {
                TableName = "Clinicians",
                isGuid = true,
                isLong = false,
                KeyField = "UserId"
            },
            new ToGenerate
            {
                TableName = "CorrectionFactors",
                isGuid = false,
                isLong = false,
                KeyField = "FactorId"
            },
            new ToGenerate
            {
                TableName = "DailyTimeSlots",
                isGuid = false,
                isLong = false,
                KeyField = "TimeSlotId"
            },
            new ToGenerate
            {
                TableName = "DatabaseInfo",
                isGuid = false,
                isLong = false,
                KeyField = "Id"
            },
            new ToGenerate
            {
                TableName = "DataLinkLog",
                isGuid = false,
                isLong = false,
                KeyField = "LinkId"
            },
            new ToGenerate
            {
                TableName = "DataShareCategories",
                isGuid = false,
                isLong = false,
                KeyField = "CategoryId"
            },
            new ToGenerate
            {
                TableName = "DataShareRequestLog",
                isGuid = false,
                isLong = false,
                KeyField = "RequestId"
            },
            new ToGenerate
            {
                TableName = "DeviceData",
                isGuid = false,
                isLong = false,
                KeyField = "DataSetId"
            },
            new ToGenerate
            {
                TableName = "DeviceSettings",
                isGuid = false,
                isLong = false,
                KeyField = "SettingId"
            },
            new ToGenerate
            {
                TableName = "DiabetesControlTypes",
                isGuid = false,
                isLong = false,
                KeyField = "TypeId"
            },
            new ToGenerate
            {
                TableName = "DiabetesManagementData",
                isGuid = false,
                isLong = false,
                KeyField = "DMDataId"
            },
            new ToGenerate
            {
                TableName = "DiabetesManagementTypes",
                isGuid = false,
                isLong = false,
                KeyField = "TypeId"
            },
            new ToGenerate
            {
                TableName = "EndUserLicenseAgreements",
                isGuid = false,
                isLong = false,
                KeyField = "AgreementId"
            },
            new ToGenerate
            {
                TableName = "Institutions",
                isGuid = true,
                isLong = false,
                KeyField = "InstitutionId"
            },
            new ToGenerate
            {
                TableName = "InsulinBrands",
                isGuid = false,
                isLong = false,
                KeyField = "InsulinBrandId"
            },
            new ToGenerate
            {
                TableName = "InsulinCarbRatio",
                isGuid = false,
                isLong = false,
                KeyField = "RatioId"
            },
            new ToGenerate
            {
                TableName = "InsulinCorrections",
                isGuid = false,
                isLong = false,
                KeyField = "CorrectionId"
            },
            new ToGenerate
            {
                TableName = "InsulinMethods",
                isGuid = false,
                isLong = false,
                KeyField = "InsulinMethodId"
            },
            new ToGenerate
            {
                TableName = "InsulinTypes",
                isGuid = false,
                isLong = false,
                KeyField = "InsulinTypeId"
            },
            new ToGenerate
            {
                TableName = "InsuranceAddresses",
                isGuid = false,
                isLong = false,
                KeyField = "AddressId"
            },
            new ToGenerate
            {
                TableName = "InsuranceContacts",
                isGuid = false,
                isLong = false,
                KeyField = "ContactId"
            },
            new ToGenerate
            {
                TableName = "InsurancePlans",
                isGuid = false,
                isLong = false,
                KeyField = "PlanId"
            },
            new ToGenerate
            {
                TableName = "InsuranceProviders",
                isGuid = false,
                isLong = false,
                KeyField = "CompanyId"
            },
            new ToGenerate
            {
                TableName = "NutritionReadings",
                isGuid = false,
                isLong = false,
                KeyField = "ReadingId"
            },
            new ToGenerate
            {
                TableName = "PasswordHistories",
                isGuid = false,
                isLong = false,
                KeyField = "HistoryId"
            },
            new ToGenerate
            {
                TableName = "PatientAddresses",
                isGuid = false,
                isLong = false,
                KeyField = "AddressId"
            },
            new ToGenerate
            {
                TableName = "PatientDevices",
                isGuid = false,
                isLong = false,
                KeyField = "DeviceId"
            },
            new ToGenerate
            {
                TableName = "PatientLinkLogs",
                isGuid = false,
                isLong = false,
                KeyField = "LinkId"
            },
            new ToGenerate
            {
                TableName = "PatientPhoneNumbers",
                isGuid = false,
                isLong = false,
                KeyField = "PhoneId"
            },
            new ToGenerate
            {
                TableName = "Patients",
                isGuid = true,
                isLong = false,
                KeyField = "UserId"
            },
            new ToGenerate
            {
                TableName = "Patients_Institutions",
                isGuid = true,
                isLong = false,
                KeyField = "UserId"
            },
            new ToGenerate
            {
                TableName = "Patients_InsurancePlans",
                isGuid = true,
                isLong = false,
                KeyField = "UserId"
            },
            new ToGenerate
            {
                TableName = "PaymentMethod",
                isGuid = false,
                isLong = false,
                KeyField = "MethodId"
            },
            new ToGenerate
            {
                TableName = "Payments",
                isGuid = false,
                isLong = false,
                KeyField = "PaymentId"
            },
            new ToGenerate
            {
                TableName = "PayPal",
                isGuid = false,
                isLong = false,
                KeyField = "PayPalId"
            },
            new ToGenerate
            {
                TableName = "PhysiologicalReadings",
                isGuid = false,
                isLong = false,
                KeyField = "ReadingId"
            },
            new ToGenerate
            {
                TableName = "PumpPrograms",
                isGuid = false,
                isLong = false,
                KeyField = "PumpProgramId"
            },
            new ToGenerate
            {
                TableName = "Pumps",
                isGuid = true,
                isLong = false,
                KeyField = "PumpKeyId"
            },
            new ToGenerate
            {
                TableName = "PumpSettings",
                isGuid = false,
                isLong = false,
                KeyField = "SettingId"
            },
            new ToGenerate
            {
                TableName = "ReadingErrors",
                isGuid = false,
                isLong = false,
                KeyField = "ErrorId"
            },
            new ToGenerate
            {
                TableName = "ReadingEvents",
                isGuid = false,
                isLong = false,
                KeyField = "Eventid"
            },
            new ToGenerate
            {
                TableName = "ReadingEventTypes",
                isGuid = false,
                isLong = false,
                KeyField = "EventId"
            },
            new ToGenerate
            {
                TableName = "ReadingHeaders",
                isGuid = true,
                isLong = false,
                KeyField = "ReadingKeyId"
            },
            new ToGenerate
            {
                TableName = "SharedAreas",
                isGuid = false,
                isLong = false,
                KeyField = "ShareId"
            },
            new ToGenerate
            {
                TableName = "Subscriptions",
                isGuid = false,
                isLong = false,
                KeyField = "SubscriptionId"
            },
            new ToGenerate
            {
                TableName = "SubscriptionType",
                isGuid = false,
                isLong = false,
                KeyField = "SubscriptionTypeId"
            },
            new ToGenerate
            {
                TableName = "TensReadings",
                isGuid = false,
                isLong = false,
                KeyField = "ReadingId"
            },
            new ToGenerate
            {
                TableName = "TherapyTypes",
                isGuid = false,
                isLong = false,
                KeyField = "TypeId"
            },
            new ToGenerate
            {
                TableName = "TotalDailyInsulinDeliveries",
                isGuid = false,
                isLong = false,
                KeyField = "DeliveryId"
            },
            new ToGenerate
            {
                TableName = "UserAuthentications",
                isGuid = false,
                isLong = false,
                KeyField = "AuthenticationId"
            },
            new ToGenerate
            {
                TableName = "UserPhotos",
                isGuid = true,
                isLong = false,
                KeyField = "UserId"
            },
            new ToGenerate
            {
                TableName = "Users",
                isGuid = true,
                isLong = false,
                KeyField = "UserId"
            },
            new ToGenerate
            {
                TableName = "UserTypes",
                isGuid = false,
                isLong = false,
                KeyField = "TypeId"
            }

        };

        string basepath = @"C:\Users\dmurawski\Source\Repos\NuDataDb\NuDataDb\Repositories\Repo\";
        string testBasePath = @"C:\Users\dmurawski\Source\Repos\NuDataDb\NuDataDb.Test\RepoTest\";

        public void GenRepoCode()
        {
            foreach(var x in ToGen)
            {
                var ToFile =
@"using NuDataDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NuDataDb.Repositories
{
    public class " + x.TableName + @"Repo : BaseRepo<" + x.TableName + @">
    {
        public " + x.TableName + @"Repo(NuMedicsGlobalContext dbContext) : base(dbContext)
        {
        }

        public override " + x.TableName + @" GetSingle(" + (x.isGuid ? @"Guid" : (x.isLong ? @"Int64" : @"int" ) ) + @" id)
        {
            return ctx." + x.TableName + @".FirstOrDefault(f => f." + x.KeyField + @" == id);
        }

        public override void Delete(" + (x.isGuid ? @"Guid" : (x.isLong ? @"Int64" : @"int")) + @" id)
        {
            var del = ctx." + x.TableName + @".FirstOrDefault(f => f." + x.KeyField + @" == id);
            if (del != null)
            {
                ctx.Remove(del);
                Save();
            }
        }
    }
}
";
                File.WriteAllText(basepath + x.TableName + "Repo.cs", ToFile);
            }
        }

        public void GenRepoTestCode()
        {
            foreach (var x in ToGen)
            {
                var ToFile =
@"using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuDataDb.EF;
using NuDataDb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NuDataDb.Test
{
    [TestClass]
    public class " + x.TableName + @"nRepoTest : BaseUnitTest<" + x.TableName + @">
    {
        Int64 itrtr64 = 0;
        int itrtr32 = 0;

        protected " + x.TableName + @"Repo repo;

        protected override void SetContextData()
        {
            repo = new " + x.TableName + @"Repo(testCtx);

            var b = new Faker<" + x.TableName + @">()
                .RuleFor(r => r." + x.KeyField + @", f => " + (x.isGuid ? @"f.Random.Uuid()" : (x.isLong ? @"itrtr64++" : @"itrtr32++" ) ) + @");

            var bs = b.Generate(3).OrderBy(o => o." + x.KeyField + @").ThenBy(o => o.SupportEmail).ToList();
            FakeCollection.AddRange(bs);


            testCtx." + x.TableName + @".AddRange(bs);
            int added = testCtx.SaveChanges();
            
        }

        [TestMethod]
        public void GetSingle" + x.TableName + @"()
        {
            var fakeApp = FakeCollection.First();
            var single = repo.GetSingle(fakeApp." + x.KeyField + @");

            Assert.AreEqual(fakeApp." + x.KeyField + @", single." + x.KeyField + @");
            Assert.AreEqual(fakeApp.ApplicationName, single.ApplicationName);
        }

        public void GetSingle" + x.KeyField + @"NotExist()
        {
            var fakeId = 333;
            var single = repo.GetSingle(fakeId);

            Assert.IsNull(single);
        }


        [TestMethod]
        public void Delete" + x.TableName + @"()
        {
            var currentCnt = testCtx." + x.TableName + @".Count();

            var entity = testCtx." + x.TableName + @".First();
            repo.Delete(entity." + x.KeyField + @");
            repo.Save();

            Assert.IsTrue(testCtx." + x.TableName + @".Count() == --currentCnt);
        }

        public void Delete" + x.KeyField + @"NotExist()
        {
            var currentCnt = testCtx.AppSettings.Count();

            var fakeId = " + (x.isGuid ? @"Guid.NewGuid()" : (x.isLong ? @"itrtr64" : @"itrtr32") ) + @";
            repo.Delete(fakeId);
            repo.Save();

            Assert.IsTrue(testCtx.AppSettings.Count() == currentCnt);
        }
    }
}
";
                File.WriteAllText(testBasePath + x.TableName + "RepoTest.cs", ToFile);
            }
        }
    }
}
