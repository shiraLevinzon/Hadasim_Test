using Microsoft.AspNetCore.Mvc;
using ServerSide.Models;
using System.Data.SqlClient;

namespace ServerSide.Data
{
    public class DataAccess
    {
        private readonly string connectionString;

        public DataAccess(string conString)
        {
            connectionString = conString;
        }
        // GET api/patientrecords

        public Member GetMemberById(int id)
        {

            Member member = new Member();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Member WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            member.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            member.Name = reader.GetString(reader.GetOrdinal("Name"));
                            member.Address = reader.GetString(reader.GetOrdinal("Address"));
                            member.Birthday = reader.GetDateTime(reader.GetOrdinal("Birthday"));
                            member.Telephone = reader.GetString(reader.GetOrdinal("Telephone"));
                            member.Mobile = reader.GetString(reader.GetOrdinal("Mobile"));
                            member.PositiveAnswerDate = reader.GetDateTime(reader.GetOrdinal("PositiveAnswerDate"));
                            member.RecoveryDate = reader.GetDateTime(reader.GetOrdinal("RecoveryDate"));
                        }
                        if (member.Id == 0) { return null; }
                        else { return member; }

                    }


                }
            }

        }

        public List<Member> GetMembers()
        {
            List<Member> members = new List<Member>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Member";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Member member = new Member
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Address = reader.GetString(reader.GetOrdinal("Address")),
                                Birthday = reader.GetDateTime(reader.GetOrdinal("Birthday")),
                                Telephone = reader.GetString(reader.GetOrdinal("Telephone")),
                                Mobile = reader.GetString(reader.GetOrdinal("Mobile")),
                                PositiveAnswerDate = reader.GetDateTime(reader.GetOrdinal("PositiveAnswerDate")),
                                RecoveryDate = reader.GetDateTime(reader.GetOrdinal("RecoveryDate"))

                            };

                            members.Add(member);
                        }


                    }
                }
            }
            return members;
        }
        public List<Vaccine> GetVaccines(int id)
        {
            List<Vaccine> vaccines = new List<Vaccine>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Vaccine WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Vaccine vaccine = new Vaccine();
                            vaccine.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            vaccine.VaccinationDate = reader.GetDateTime(reader.GetOrdinal("VaccinationDate"));
                            vaccine.Producer = reader.GetString(reader.GetOrdinal("Producer"));
                            vaccines.Add(vaccine);
                        }


                    }
                }
            }
            return vaccines;
        }

        public void AddMember([FromBody] Member member)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {


                    command.CommandText = "INSERT INTO Member (Id,Name, Address, Birthday, Telephone, Mobile, PositiveAnswerDate, RecoveryDate) VALUES (@Id, @Name, @Address, @Birthday, @Telephone, @Mobile, @PositiveAnswerDate, @RecoveryDate)";
                    command.Parameters.AddWithValue("@Id", member.Id);
                    command.Parameters.AddWithValue("@Name", member.Name);
                    command.Parameters.AddWithValue("@Address", member.Address);
                    command.Parameters.AddWithValue("@Birthday", member.Birthday);
                    command.Parameters.AddWithValue("@Telephone", member.Telephone);
                    command.Parameters.AddWithValue("@Mobile", member.Mobile);
                    command.Parameters.AddWithValue("@PositiveAnswerDate", member.PositiveAnswerDate);
                    command.Parameters.AddWithValue("@RecoveryDate", member.RecoveryDate);
                    command.ExecuteNonQuery();


                }
            }

        }
        public void AddVaccine([FromBody] Vaccine vaccine)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(*) FROM Member WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", vaccine.Id);
                    int count = (int)command.ExecuteScalar();
                    if (count == 1)
                    {
                        command.Parameters.Clear();
                        command.CommandText = "SELECT COUNT(*) FROM Vaccine WHERE Id = @Id";
                        command.Parameters.AddWithValue("@Id", vaccine.Id);
                        count = (int)command.ExecuteScalar();
                        if (count < 4)
                        {
                            command.Parameters.Clear();
                            command.CommandText = "INSERT INTO Vaccine (Id,VaccinationDate, Producer) VALUES (@Id, @VaccinationDate, @Producer)";
                            command.Parameters.AddWithValue("@Id", vaccine.Id);
                            command.Parameters.AddWithValue("@VaccinationDate", vaccine.VaccinationDate);
                            command.Parameters.AddWithValue("@Producer", vaccine.Producer);

                            command.ExecuteNonQuery();
                        }
                    }


                }
            }

        }
    }
}
