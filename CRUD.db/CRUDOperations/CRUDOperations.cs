using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD.Models;

namespace CRUD.db.CRUDOperations
{
    public class CRUDOperations
    {
        public int Add(CustomerModel obj)
        {
            using (var context = new CustomerDBEntities())
            {
                Customer data = new Customer()
                {
                    firstName = obj.firstName,
                    lastName = obj.lastName,
                    email = obj.email,
                    phone = obj.phone,
                    Address = new Address()
                    {
                        country = obj.Address.country,
                        city = obj.Address.city,
                        addressline = obj.Address.addressline
                    }
                };

                context.Customer.Add(data);
                context.SaveChanges();

                return data.id;
            }

        }

        public List<CustomerModel> ReadAll()
        {
            using (var context = new CustomerDBEntities())
            {
                var result = context.Customer.
                    Select(x=>new CustomerModel()
                    {
                        id = x.id,
                        firstName = x.firstName,
                        lastName = x.lastName,
                        email = x.email,
                        phone = x.phone,
                        addressId = x.addressId,
                        Address = new AddressModel()
                        {
                            addressline = x.Address.addressline,
                            country = x.Address.country,
                            city = x.Address.city
                        }
                    }
                    ).ToList();
                return result;
            }
        }

        public CustomerModel Read(int id)
        {
            using (var context = new CustomerDBEntities())
            {
                var result = context.Customer
                    .Where(x => x.id == id)
                    .Select(x => new CustomerModel()
                    {
                        id = x.id,
                        firstName = x.firstName,
                        lastName = x.lastName,
                        email = x.email,
                        phone = x.phone,
                        addressId = x.addressId,
                        Address = new AddressModel()
                        {
                            addressline = x.Address.addressline,
                            country = x.Address.country,
                            city = x.Address.city
                        }
                    }
                    ).FirstOrDefault();
                return result;
            }
        }

        public bool Edit(int id,CustomerModel obj)
        {
            using (var context = new CustomerDBEntities())
            {
                var customer = context.Customer.FirstOrDefault(x => x.id == id);

                if (customer != null)
                {
                    customer.firstName = obj.firstName;
                    customer.lastName = obj.lastName;
                    customer.email = obj.email;
                    customer.phone = obj.phone;
                    customer.Address.country = obj.Address.country;
                    customer.Address.city = obj.Address.city;
                    customer.Address.addressline = obj.Address.addressline;
                }

                context.SaveChanges();
                return true;
            }
        }

        public bool Delete(int id)
        {
            using(var context = new CustomerDBEntities())
            {
                var temp = context.Customer.FirstOrDefault(x => x.id == id);

                if (temp != null)
                {
                    context.Customer.Remove(temp);
                    context.SaveChanges();
                    return true;
                }
                return false;
                


            }
        }
    }
}
