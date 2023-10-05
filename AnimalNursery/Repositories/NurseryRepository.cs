using AnimalNursery.Infrastructure.Base;
using AnimalNursery.Models.Base;
using AnimalNursery.Repositories.Base;
using AnimalNursery.Repositories.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace AnimalNursery.Repositories
{
    public class NurseryRepository : INurseryRepository
    {
        public ObservableCollection<Animal> GetAll(ObservableCollection<Animal> NurseryCollection)
        {
			try
			{
                if (!InternetCheck.CheckSkyNET())
                    return NurseryCollection;
                using (MySqlCommand cmd = new MySqlCommand("GetAll", 
                    ConnectionDB.GetInstance.GetConnection()))
                {
                    ConnectionDB.GetInstance.OpenConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var animal = new Animal(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetDouble(2),
                                    reader.GetDouble(3),
                                    reader.GetDouble(4),
                                    reader.GetString(5),
                                    reader.GetString(6));
                                NurseryCollection.Add(animal);
                            }
                        }
                        reader.Close();
                    }
                    return NurseryCollection;
                }
            }
            catch (Exception) { return NurseryCollection; }
            finally { ConnectionDB.GetInstance.CloseConnection(); }
        }
        public bool Add (Animal animal)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand cmd = new MySqlCommand("AddAnimal", 
                    ConnectionDB.GetInstance.GetConnection()))
                {
                    ConnectionDB.GetInstance.OpenConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue($"nameUser", animal.Name);
                    cmd.Parameters.AddWithValue($"ageUser", animal.Age);
                    cmd.Parameters.AddWithValue($"heightUser", animal.Height);
                    cmd.Parameters.AddWithValue($"weightUser", animal.Weight);
                    cmd.Parameters.AddWithValue($"classAnimalUser", animal.ClassAnimal);
                    cmd.Parameters.AddWithValue($"commandUser", animal.Command);
                    if (cmd.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch (Exception) { return false; }
            finally { ConnectionDB.GetInstance.CloseConnection(); }
        }
        public bool Update (Animal animal)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand cmd = new MySqlCommand("UpdateAnimal",
                    ConnectionDB.GetInstance.GetConnection()))
                {
                    ConnectionDB.GetInstance.OpenConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nameUser", animal.Name);
                    cmd.Parameters.AddWithValue("@ageUser", animal.Age);
                    cmd.Parameters.AddWithValue("@heightUser", animal.Height);
                    cmd.Parameters.AddWithValue("@weightUser", animal.Weight);
                    cmd.Parameters.AddWithValue("@classAnimalUser", animal.ClassAnimal);
                    cmd.Parameters.AddWithValue("@commandUser", animal.Command);
                    cmd.Parameters.AddWithValue("@IdUser", animal.Id);

                    if (cmd.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch (Exception) { return false; }
            finally { ConnectionDB.GetInstance.CloseConnection(); }
        }
        public bool Delete(Animal animal)
        {
            try
            {
                if (!InternetCheck.CheckSkyNET())
                    return false;
                using (MySqlCommand cmd = new MySqlCommand("DeleteAnimal",
                    ConnectionDB.GetInstance.GetConnection()))
                {
                    ConnectionDB.GetInstance.OpenConnection();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue($"IdUser", animal.Id);

                    if (cmd.ExecuteNonQuery() == 1) return true;
                    else return false;
                }
            }
            catch (Exception) { return false; }
            finally { ConnectionDB.GetInstance.CloseConnection(); }
        }
    }
}
