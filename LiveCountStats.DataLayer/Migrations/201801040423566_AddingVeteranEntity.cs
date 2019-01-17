namespace LivecountStats.DataLayer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingVeteranEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Veteran",
                c => new
                    {
                        VeteranId = c.Int(nullable: false, identity: true),
                        VeteranName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.VeteranId);
            
            CreateIndex("dbo.CountMessage", "author");

            Sql(@"INSERT INTO dbo.Veteran (VeteranName) VALUES
('7444774774'), ('74747474747474747474'), ('dominodan123main'), ('VitanimB16'), ('_VitaminB12'), ('Chalupa_Dude'), ('parker_sphere'), ('c8h10n4o2_caffeine'), ('7777777_7777777'), ('NaCl_SodiumChloride'), ('h2co3_carbonic_acid'), ('gordonptpt8'), ('only_counts_evens'), ('only_counts_odds'), ('amazingpikachu_39'), ('Iamquick36'), ('db2c_burritate'), ('HydrogenHydroxideHOH'), ('Iamrapid36'), ('bro4_perbromate'), ('TOP_5239550'), ('YouShouldLearn2Count'), ('riderideVEVO'), ('Urblu'), ('Queen_of_LC'), ('SolidGoldGyarados'), ('Cinderella420'), ('TOP_747'), ('TOP_74'), ('r_livecounting'), ('TOP_10100'), ('TOP_6969'), ('TOP_4702633'), ('facing_an_error'), ('i_am_not_david'), ('davidjl12345'), ('h2o_water'), ('TOP_1010'), ('TOP_47'), ('AngelTacoDog'), ('4663017'), ('DBCAlt'), ('TOP_6689'), ('C2H5OH_ethanol'), ('c2h3o2_acetate'), ('_unbreakmyheart_'), ('TheButtOfSs'), ('imrichlol'), ('queen_of_thebans'), ('parker_hyper-cube'), ('CountMasterWhit'), ('VitaminG420'), ('VitaminB420'), ('TOP_12367'), ('TOP_12376'), ('xia__'), ('pileofmoney'), ('clo3_chlorate'), ('TOP_539'), ('SupBitchItsWhit'), ('FUCK_RIT_HOUSING'), ('kikkererwt'), ('spud_deluxe'), ('NewtVargas'), ('NubCaeks'), ('JUGEMU_JUGEMU'), ('dr_dinero'), ('EnoughALTSAlready'), ('Sanerthanpiyush'), ('TOP_-1'), ('T0P_28'), ('PM_ME_STOCK_PICS_2'), ('NOT_PM_ME_STOCK_PICS'), ('PM_ME_STOCK_PICS'), ('NumberOfTheDayBot'), ('AlexDoesWhatever'), ('heavu9'), ('Brackish_Onion'), ('jm_03'), ('undeadcounting'), ('Roland_Schaosid'), ('CotDOlympicsBot'), ('stalkpiyush'), ('sanerthanKCX'), ('waytoomanyalts'), ('stalkcm'), ('runforrestrun36'), ('Tranquilsundeath'), ('runforestrun36'), ('davidjl1234'), ('counting_lc'), ('overdrafts'), ('h2co3_carbonicacid'), ('TOP_7777777777777777'), ('piyushsharma777'), ('Tranquilsunset'), ('mr_carbonate'), ('piyushsharma369'), ('whit_stalks_piy'), ('Justsnipemealready'), ('piy_worships_whit'), ('Weirdanddifficult'), ('Iamfast36'), ('Iamslow36'), ('Iamsortaspeedy39'), ('Iamslow37'), ('stalkpiy'), ('TOP_369'), ('Sgt_Carrot'), ('co4_carbonate'), ('MasterofBananaz'), ('friedelcraft'), ('Funny_For_No_Reason'), ('_rschaosid'), ('new_artbn'), ('1294000'), ('sidebar_interim'), ('1293000'), ('livecount_simulator'), ('qwertyloolghost'), ('livecounting_sidebar'), ('EnoughGETSAlready'), ('leavelivecounting'), ('banned_thanks_obama'), ('Robert_Schaosid'), ('clo4_perchlorate'), ('BOTTOM_20'), ('amazingsuicune_38'), ('h3o_hydronium'), ('c4h4n2o3_barbiturate'), ('Intelligentstocks'), ('cro4_chromate'), ('MnO4_permanganate'), ('LiterallyPixel'), ('bo3_borate'), ('GrapheneTrillionaire'), ('po4_phosphate'), ('piyush_s_dog'), ('so4_sulphate'), ('no3_nitrate'), ('TOP_27'), ('dead_mentions'), ('IWillDeleteThe2y75'), ('Dumbstocks'), ('Stupidstocks'), ('TOP_2017'), ('Iive_mentions'), ('913805'), ('99999999999999999988'), ('countingcomments'), ('livecounting'), ('AltOfAmazingPikachu'), ('IWillDeleteThe8y3'), ('20CharachterUsername'), ('IWillDeleteThe5r1'), ('anothershittyctrl'), ('iLuke2210'), ('TOP_2O'), ('LewisMCYoutube2'), ('TOP_16'), ('rschoasid'), ('Nooraell'), ('joinlivecounting'), ('TOP_69'), ('count_better'), ('oreganomissile'), ('Richard_Schaosid'), ('TOP_43597'), ('T0P_20'), ('TOP_2'), ('TOP_9999999999999999'), ('live_mentions'), ('TOP_9'), ('TOP_0'), ('TOP_6'), ('TOP_4'), ('TOP_420'), ('dontcareiliveit'), ('TOP_18'), ('TOP_19'), ('qwertlool'), ('thedowntroddend'), ('DontCareILoveIt'), ('Requina_Schaosid'), ('10CountsADay'), ('idkingcaspiany9000'), ('Whit4You'), ('TheBestNumberOfHats'), ('anothershittyalt'), ('KingCaspianY'), ('illfuckyourmother'), ('counting45'), ('FartyMcRemovedsolid'), ('Nevare88'), ('i_eatProstitutes'), ('sfacets'), ('Sharpeye469'), ('theolddarkness'), ('thispotatocandomath'), ('Ryan_Schaosid'), ('Ravi_Schaosid'), ('mypasswordis80five'), ('ignisfire16'), ('TOP_20'), ('amazingpikachu_38'), ('dominodan123'), ('Smartstocks'), ('davidjl123'), ('piyushsharma301'), ('smarvin6689'), ('qwertylool'), ('gordonpt8'), ('QuestoGuy'), ('co3_carbonate'), ('rideride'), ('Iamspeedy36'), ('rschaosid'), ('Tranquilsunrise'), ('DemonBurritoCat'), ('KingCaspianX'), ('abplows'), ('VitaminB16'), ('parker_cube'), ('Kris18'), ('xHOCKEYx12'), ('randomusername123458'), ('darthvader1521'), ('supersammy00'), ('albert471'), ('SolidGoldMagikarp'), ('xXnapa1mXx'), ('GrunfTNT'), ('Removedpixel'), ('Luigi86101'), ('CarbonSpectre'), ('Lifeofchrome'), ('animatedtwig'), ('TheGlobeIsRound'), ('TheNitromeFan'), ('orangey10'), ('_ntrpy'), ('thetiredlemur'), ('kinetic37'), ('ExSeaD'), ('o99o99'), ('MewDP'), ('bluesolid'), ('ryan2222'), ('WGJC8463'), ('HiddenMafia'), ('scottm3'), ('DanTheStripe'), ('artbn')
");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CountMessage", new[] { "author" });
            DropTable("dbo.Veteran");
        }
    }
}
