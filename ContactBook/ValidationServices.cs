using ContactBook.Controllers;
using ContactBook.core;
using ContactBook.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace ContactBook
{
    public class ValidationServices
    {
        BaseApiController convert = new BaseApiController();
        public bool IsValid(Contact contact)
        {
            var result1 = ValidatePhones(contact.Phones);
            var result2 = ValidateEmail(contact.Emails);
            var result3 = ValidateBirthday(contact.DateOfBirth);
            var result4 = ValidateAdress(contact.Adresses);
            var result5 = ValidateFullName(contact);
            if (result1 && result2 && result3 && result4 && result5)
            {
                return true;
            }
            else
                return false;

        }
        public bool ValidateFullName(Contact contact)
        {
            return !string.IsNullOrEmpty(contact.Name) && !string.IsNullOrEmpty(contact.LastName);
        }
        public bool ValidatePhones(ICollection<ContactPhone> phones)
        {
            foreach (var p in phones)
            {
                if (p.Type == PhoneType.Home || p.Type == PhoneType.Work)
                {
                    return p.PhoneNumber.Length == 8 && p.PhoneNumber.First().Equals('6') || p.PhoneNumber == string.Empty;
                }
                if (p.Type == PhoneType.MobilePhone)
                    return  p.PhoneNumber.Length == 8 && p.PhoneNumber.First().Equals('2') || p.PhoneNumber == string.Empty;
            }
            return true;
            
        }
        public bool ValidateEmail(ICollection<ContactEmail> emails)
        {
            foreach (var e in emails)
            {
                return e.Email.Contains("@") && e.Email.Contains(".") || e.Email == string.Empty;
                
            }
            return true;
        }
        public bool ValidateBirthday(string birthday)
        {
            if (birthday == string.Empty)
                return true;
            try
            {
                var compare = DateTime.Compare(DateTime.Now, DateTime.Parse(birthday));
                return compare > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ValidateAdress(ICollection<ContactAdress> contactAdresses)
        {
            var obj = new JsonAdressResponseModel();
            foreach (var adress in contactAdresses)
            {
                if (string.Empty == adress.City && adress.Street == string.Empty && adress.HouseNumber == string.Empty)
                    continue;
                string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + adress.Street + adress.HouseNumber + adress.City + "&key=AIzaSyBhwgkjOOK6Qb6D4eLVk1oROcFMK35UD0E";
                var response = GetRequest(url);
                obj = DeserializeJson(response);
                if(obj.Status != "OK" || obj.address_Components.Length < 5)
                    return false;
                adress.lat = obj.lat;
                adress.lng = obj.lng;
            }
            return true;
        }
        private string GetRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var responseReader = new StreamReader(webStream);
            var response = responseReader.ReadToEnd();
            responseReader.Close();
            return response;
        }
        private JsonAdressResponseModel DeserializeJson(string response)
        {
            var obj = JsonConvert.DeserializeObject<Rootobject>(response);
            List<JsonAdressResponseModel> result = obj.results.Select(x => new JsonAdressResponseModel
            {
                address_Components = x.address_components,
                Status = obj.status,
                lat = x.geometry.location.lat,
                lng = x.geometry.location.lng,
            }).ToList();
            if (result.Count == 0)
                return new JsonAdressResponseModel() {
                    Status = obj.status
                };
            return new JsonAdressResponseModel() { 
                    address_Components = result[0].address_Components,
                Status = obj.status,
                lat = result[0].lat,
                lng = result[0].lng,
            };
        }
        
    }
    
}