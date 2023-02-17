using System;
using System.Web;
using System.Web.UI;
using Syn.Bot.Channels.Testing;
using Syn.Bot.Channels.Widget;
using Syn.Bot.Oscova;
using System.Diagnostics;
using Syn.Bot.Oscova.Attributes;

namespace TomTom_Info_Page
{
    public partial class BotService : System.Web.UI.Page
    {
        private static WidgetChannel WidgetChannel { get; }
        private static OscovaBot Bot { get; }
        [Fallback]
        public void DefaultFallback(Context context, Result result)
        {
            result.SendResponse("I am sorry. Could you please rephrase that for me?");
        }
        static BotService()
        {
            Bot = new OscovaBot();
            WidgetChannel = new WidgetChannel(Bot);
            //Add the pre-built channel test dialog.
            Bot.Dialogs.Add(new defaultm());
            // Bot.Dialogs.Add(new ChannelTestDialog(Bot));
            ///Bot.Configuration.RequiredRecognizersOnly = true;
            ///Bot.Configuration.RemoveContextOnFallback = false;
            // Bot.Configuration.ContextLifespan = 1;
            //  Bot.Configuration.Scoring.MinimumScore = 0.4;

            Bot.Dialogs.Add(new greet());
            Bot.Dialogs.Add(new not_committing());
            Bot.Dialogs.Add(new azure());
            Bot.Dialogs.Add(new iris());
            Bot.Dialogs.Add(new system());
            Bot.Dialogs.Add(new workload());
            Bot.Dialogs.Add(new ArcGIS());
            Bot.Dialogs.Add(new bye());
            Bot.Dialogs.Add(new test());
            Bot.Dialogs.Add(new disconnection());
            Bot.Dialogs.Add(new VPN());
            Bot.Dialogs.Add(new Power());
            Bot.Dialogs.Add(new login());
            Bot.Dialogs.Add(new network());
            Bot.Dialogs.Add(new source());
            Bot.Dialogs.Add(new QGIS());
            Bot.Dialogs.Add(new compensate());
            Bot.Dialogs.Add(new shortage());
            Bot.Dialogs.Add(new explicit_req());
            Bot.Dialogs.Add(new delay());
            Bot.Dialogs.Add(new scope());
            Bot.Dialogs.Add(new test2());

            Bot.Dialogs.Add(new thanks());  //Start training.
            Bot.Trainer.StartTraining();

            var websiteUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            WidgetChannel.ServiceUrl = websiteUrl + "/BotService.aspx";
            WidgetChannel.ResourceUrl = websiteUrl + "/BotResources";
            WidgetChannel.WidgetTitle = "Welcome to the <b>WTC Chatbot</b>.<br> How may I assist you?<br>";
            WidgetChannel.LaunchButtonText = "Ask";
            WidgetChannel.InputPlaceHolder = "Ask your query here...";

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            WidgetChannel.Process(Request, Response);
        }
        internal class greet : Dialog
        {
            [Expression("how do you do")]
            [Expression("hi")]
            [Expression("howdy")]
            [Expression("hello")]
            [Expression("how are you?")]
            [Expression("cze")]
            [Expression("czesc")]
            [Expression("cześć")]
            [Expression("good morning")]
            [Expression("good evening")]
            [Intent(Name = "greet")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("Hello! How can I help you?");
            }
        }
        internal class not_committing : Dialog
        {
            [Expression("not commit")]
            [Expression("can't commit")]
            [Expression("txn")]
            [Expression("txns")]
            [Expression("txns not committing")]
            [Expression("not committing")]
            [Expression("commit issue")]
            [Expression("commit")]
            [Expression("cartopia")]
            [Expression("transactions")]

            [Intent(Name = "not_commit")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This is a <b>Platform issue</b> which should go under <b>Cartopia Down</b>. Don't forget to mention the <b>ticket number</b> in the remarks.");
            }
        }
        internal class azure : Dialog
        {
            [Expression("azure connection")]
            [Expression("azure issue")]
            [Expression("azure problem")]
            [Expression("azure")]
            [Expression("windows 10")]
            [Expression("window 10")]
            [Expression("win 10")]
            [Expression("win10")]
            [Expression("window10")]
            [Expression("azure login")]

            [Intent(Name = "azure")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This is a <b>WFH TUN issue</b>, this should go under <b>Azure Connections</b>. Don't forget to mention the <b>ticket number</b> in the remarks.");
            }
        }
        internal class iris : Dialog
        {
            [Expression("IRIS")]
            [Expression("Iris issue")]
            [Expression("iris down")]
            [Expression("iris")]
            [Expression("irs")]
            [Expression("iras")]

            [Intent(Name = "iris")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This is a <b>Platform issue</b> which should go under <b>Iris Down</b>. Don't forget to mention the <b>ticket number</b> in the remarks.");
            }
        }
        internal class system : Dialog
        {
            [Expression("PC problem")]
            [Expression("system restart")]
            [Expression("system")]
            [Expression("install pulse")]
            [Expression("restart")]
            [Expression("laptop")]
            [Expression("pc")]

            [Intent(Name = "system")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This is a <b>Local IT Issue</b> which should go under <b>PC Problem</b>. Don't forget to mention the <b>ticket number</b>(if you have one) in the remarks.");
            }
        }
        internal class workload : Dialog
        {
            [Expression("workload unavailability")]
            [Expression("workload issue")]
            [Expression("work load")]
            [Expression("workload")]
            [Expression("no work present")]
            [Expression("no work")]

            [Intent(Name = "workload")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This is a <b>Workload issue</b> which should go under <b>workload unavailability</b>.");
            }
        }
        internal class ArcGIS : Dialog
        {
            [Expression("arcgis")]
            [Expression("ArcGIS down")]
            [Expression("arcgis down")]
            [Expression("arcgis")]
            [Expression("ArcGIS")]
            [Expression("arc gis")]
            [Expression("arc map")]
            [Expression("arcmap")]
            [Expression("esri")]

            [Intent(Name = "arcgis")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This is a <b>Platform Issue</b> and should go under the <b>ArcGIS sub-step</b>. Don't forget to mention the <b>ticket number</b> in the remarks.");
            }
        }





        internal class bye : Dialog
        {
            [Expression("bye")]
            [Expression("goodbye")]
            [Expression("dowidzenia")]
            [Expression("nara")]
            [Intent(Name = "bye")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("Thank you for chatting with me, hope I was able to solve your issue :)");
            }
        }
        public class test : Dialog
        {
            [Fallback]
            public void GlobalFallback(Context context, Result result)
            {
                result.SendResponse("I am sorry. Could you please rephrase that for me?");
            }
        }
        public class test2 : Dialog
        {

            [Expression("*")]
            [Intent(Name = "GlobalFallbackIntent")]
            [Fallback]
            public void GlobalFallback(Context context, Result result)
            {
                result.SendResponse("I am sorry. Could you please rephrase that for me?");
            }
        }
        public class disconnection : Dialog
        {
            [Expression("WFH disconnection")]
            [Expression("disconnect")]
            [Expression("disconnection")]
            [Expression("internet connection")]
            [Expression("internet disconnection")]
            [Intent(Name = "disconnection")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This is a <b>WFH TUN</b> issue and should go under <b>Disconnections</b> category.");
            }
        }
        public class VPN : Dialog
        {
            [Expression("vpn connection")]
            [Expression("vpn")]
            [Expression("pulse")]
            [Intent(Name = "VPN")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This is <b>WFH VPN issue</b> and should go under <b>VPN Connections</b>. Don't forget to mention the ticket number in the remarks.");
            }
        }
        public class Power : Dialog
        {
            [Expression("electricity")]
            [Expression("light")]
            [Expression("power")]
            [Expression("powercut")]

            [Intent(Name = "Power")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This is a <b>power failure issue</b> and should go under <ul><li><b>Category: Power Failure</b></li><li><b>Sub-step: Electricity off.</b></li></ul>");
            }
        }
        public class login : Dialog
        {
            [Expression("login problem")]
            [Expression("login")]

            [Intent(Name = "login")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This is a <b>login issue</b> and should go under <ul><li><b>Category: Local IT Issue</b></li><li><b>Sub-step: Login Problem</b></li></ul>Don't forget to mention the ticket number (if you have one) in the remarks.");
            }
        }
        public class network : Dialog
        {
            [Expression("network issue")]
            [Expression("network")]

            [Intent(Name = "network")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This is a <b>network issue</b> and should go under <ul><li><b>Category: Local IT Issue</b></li><li><b>Sub-step: Network Problem</b></li></ul>Don't forget to mention the ticket number (if you have one) in the remarks.");
            }
        }
        public class source : Dialog
        {
            [Expression("layer")]
            [Expression("source")]
            [Intent(Name = "source")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This is <b>source down issue</b> and should go under <ul><li><b>Category: Source Issue</b></li><li><b>Sub-step: Layer/Source Down</b></li></ul>Don't forget to mention the ticket number in the remarks.");
            }
        }
        public class QGIS : Dialog
        {
            [Expression("QGIS")]
            [Expression("qgis")]
            [Intent(Name = "QGIS")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This is a <b>QGIS down issue</b> and should go under <ul><li><b>Category: Platform Issue</b></li><li><b>Sub-step: QGIS Down</b></li></ul>Don't forget to mention the ticket number in the remarks.");
            }
        }
        public class compensate : Dialog
        {
            [Expression("compensated")]
            [Expression("compensate")]
            [Expression("delta")]
            [Expression("staggered off")]
            [Expression("compensation")]
            [Expression("comp off")]
            [Expression("compoff")]
            [Intent(Name = "compensate")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This entry should go under <ul><li><b>Sub Task Name: OT</b></li><li><b>Category: Compensate</b></li></ul>Don't forget to mention the Project Name in the remarks.");
            }
        }
        public class shortage : Dialog
        {
            [Expression("temporary working")]
            [Expression("extra work in new team")]
            [Expression("shortage")]
            [Intent(Name = "shortage")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This entry should go under <ul><li><b>Sub Task Name: OT</b></li><li><b>Category: Shortage</b></li></ul>Don't forget to mention the Project Name in the remarks.");
            }
        }
        public class explicit_req : Dialog
        {
            [Expression("overtime")]
            [Expression("paid work")]
            [Expression("explicit")]
            [Expression("extra working")]
            [Expression("approved by manager")]
            [Expression("OT")]
            [Expression("over time")]
            [Intent(Name = "explicit_req")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This entry should go under <ul><li><b>Sub Task Name: OT</b></li><li><b>Category: Explicit Requirement</b></li></ul>Don't forget to mention the Project Name in the remarks.");
            }
        }
        public class delay : Dialog
        {
            [Expression("delay")]
            [Intent(Name = "delay")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This entry should go under <ul><li><b>Sub Task Name: OT</b></li><li><b>Category: Delay</b></li></ul>Don't forget to mention the Project Name in the remarks.");
            }
        }
        public class scope : Dialog
        {
            [Expression]
            public void Default(Context context, Result result)
            {
                result.SendResponse("I am sorry. Could you please rephrase that for me?");
            }
            [Expression("scope")]
            [Expression("scope creep")]
            [Expression("scope not completed")]
            [Expression("scope change")]
            [Intent(Name = "scope")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("This entry should go under <ul><li><b>Sub Task Name: OT</b></li><li><b>Category: Scope Creep</b></li></ul>Don't forget to mention the Project Name in the remarks.");
            }
        }
         public class thanks : Dialog
        {           
            [Expression("thanks")]
            [Expression("thx")]
            [Expression("thank you")]
            [Expression("many thanks")]
            [Intent(Name = "thanks")]
            public void Answer(Context context, Result result)
            {
                result.SendResponse("You’re welcome!");
            }
        }
        public class defaultm : Dialog
        {
            [Expression]
            public void Default(Context context, Result result)
            {
                result.SendResponse("I am sorry. Could you please rephrase that for me?");
                //, "I don't quite understand the issue. Could you please put it in simple terms?");
            }
        }

    }
}