using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Services;

namespace autocomplete_custom_searchmode_demo.Web
{
    /// <summary>
    /// Summary description for PersonService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PersonService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Person> GetPersons()
        {
            return Persons();
        }

        private List<Person> Persons()
        {
            var persons = new List<Person>();
            persons.Add(new Person { FirstName = "java", SecondName = "china" });
            persons.Add(new Person { FirstName = "csharp", SecondName = "japan" });
            persons.Add(new Person { FirstName = "cplusplus", SecondName = "india" });
            persons.Add(new Person { FirstName = "ruby", SecondName = "china" });
            persons.Add(new Person { FirstName = "python", SecondName = "korea" });
            return persons;
        }
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public String FirstName { get; set; }
        [DataMember]
        public String SecondName { get; set; }
        public override String ToString()
        {
            return FirstName + " " + SecondName;
        }
    }
}
