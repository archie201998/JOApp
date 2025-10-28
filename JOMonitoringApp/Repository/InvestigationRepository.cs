using JOMonitoringApp.Interface;
using JOMonitoringApp.Model;
using JOMonitoringApp.Repository;
using System.Collections.Generic;
using System.Data;

namespace JOMonitoringApp
{
    public class InvestigationRepository : IInvestigationRepository
    {
        private readonly GenericCommands mySqlGenericCommands;
        private readonly string tableName = "tbl_investigation";

        public InvestigationRepository(GenericCommands mySqlGenericCommands)
        {
            this.mySqlGenericCommands = mySqlGenericCommands;
        }

        public bool Delete(List<InvestigationModel> entityList)
        {
            bool result = true;
            foreach (var entity in entityList)
            {
                var parameters = new object[][]
                {
                    new object[] { "@id", DbType.Int32, entity.Id }
                };

                string query = $"DELETE FROM {tableName} WHERE id = @id";

                if (!mySqlGenericCommands.ExecuteNonQuery(query, parameters))
                {
                    result = false;
                }
            }
            return result;
        }

        public Dictionary<string, string> GetRecordByID(int Id)
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetRecords()
        {
            string query = $"SELECT * FROM {tableName}";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable);
        }

        public DataTable GetRecordsBySearch(string searchText)
        {
            throw new System.NotImplementedException();
        }

        public bool IdExist(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(InvestigationModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@job_orders_id", DbType.Int32,  entity.JobOrderId },
                new object[] { "@job_order_no", DbType.String,  entity.JobOrderNo }, // Fixed: new param name
                new object[] { "@customer_name", DbType.String, entity.CustomerName },
                new object[] { "@customer_address", DbType.String, entity.CustomerAddress },
                new object[] { "@account_number", DbType.String, entity.CustomerAccountNumber },
                new object[] { "@contact_number", DbType.String, entity.CustomerContactNumber },
                new object[] { "@nature_of_complaint", DbType.String, entity.NatureOfComplaint },
                new object[] { "@meter_brand", DbType.String, entity.MeterBrand },
                new object[] { "@meter_size", DbType.String, entity.MeterSize },
                new object[] { "@meter_number", DbType.String, entity.MeterNumber },
                new object[] { "@is_approved", DbType.Int32, entity.IsApproved },
                new object[] { "@created_by", DbType.Int32, entity.CreatedBy },
            };

            string query = $"INSERT INTO {tableName} (job_orders_id, job_order_no, customer_name, customer_address, contact_number, account_number, nature_of_complaint, meter_brand, meter_size, meter_number, is_approved, created_by) VALUES (@job_orders_id, @job_order_no, @customer_name, @customer_address, @contact_number, @account_number, @nature_of_complaint, @meter_brand, @meter_size, @meter_number, @is_approved, @created_by)";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool UpdateInvestigation(InvestigationModel entity) //<-- Temporary only
        {
            var parameters = new object[][]
            {
                new object[] { "@job_orders_id", DbType.Int32,  entity.JobOrderId },
                new object[] { "@job_order_no", DbType.String,  entity.JobOrderNo },
                new object[] { "@customer_name", DbType.String, entity.CustomerName },
                new object[] { "@customer_address", DbType.String, entity.CustomerAddress },
                new object[] { "@account_number", DbType.String, entity.CustomerAccountNumber },
                new object[] { "@contact_number", DbType.String, entity.CustomerContactNumber },
                new object[] { "@nature_of_complaint", DbType.String, entity.NatureOfComplaint },
                new object[] { "@meter_brand", DbType.String, entity.MeterBrand },
                new object[] { "@meter_size", DbType.String, entity.MeterSize },
                new object[] { "@meter_number", DbType.String, entity.MeterNumber },
            };

            string query = $"UPDATE {tableName} SET " +
                            $"job_order_no = @job_order_no, " +
                            $"customer_name = @customer_name, " +
                            $"contact_number = @contact_number, " +
                            $"customer_address = @customer_address," +
                            $"account_number = @account_number," +
                            $"nature_of_complaint = @nature_of_complaint," +
                            $"meter_brand = @meter_brand," +
                            $"meter_size = @meter_size," +
                            $"meter_number = @meter_number " +
                            $"WHERE job_orders_id = @job_orders_id";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public bool Update(InvestigationModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id },
                new object[] { "@job_orders_id", DbType.Int32, entity.JobOrderId },
                new object[] { "@job_order_no", DbType.String, entity.JobOrderNo },
                new object[] { "@customer_name", DbType.String, entity.CustomerName },
                new object[] { "@customer_address", DbType.String, entity.CustomerAddress },
                new object[] { "@account_number", DbType.String, entity.CustomerAccountNumber },
                new object[] { "@nature_of_complaint", DbType.String, entity.NatureOfComplaint },
                new object[] { "@date_of_investigation", DbType.DateTime, entity.DateOfInvestigation },
                new object[] { "@investigator_comments", DbType.String, entity.InvestigatorComments },
                new object[] { "@recommendations", DbType.String, entity.Recommendations },
                new object[] { "@image_path", DbType.String, entity.ImagePath },
                new object[] { "@secondary_image_path", DbType.String, entity.SecondaryImagePath },
                new object[] { "@is_approved", DbType.Int32, entity.IsApproved },
                new object[] { "@approval_message", DbType.String, entity.ApprovalMessage },
                new object[] { "@updated_by", DbType.Int32, entity.UpdatedBy },
                new object[] { "@immediate_members_of_fam", DbType.Int32, entity.ImmediateMembersOfFam },
                new object[] { "@house_helper", DbType.Int32, entity.HouseHelper },
                new object[] { "@relatives", DbType.Int32, entity.Relatives },
                new object[] { "@boarders", DbType.Int32, entity.Boarders },
                new object[] { "@no_of_hours_served", DbType.Int32, entity.NoOfHoursServed },
                new object[] { "@no_service_outlets", DbType.Int32, entity.NoServiceOutlets },
                new object[] { "@hh_purpose", DbType.Int32, entity.HhPurpose },
                new object[] { "@government", DbType.Int32, entity.Government },
                new object[] { "@promote_trade_business", DbType.Int32, entity.PromoteTradeBusiness },
                new object[] { "@sell_to_neighbours", DbType.Int32, entity.SellToNeighbours },
                new object[] { "@alternative_source", DbType.String, entity.AlternativeSource },
                new object[] { "@meter_brand", DbType.String, entity.MeterBrand },
                new object[] { "@meter_size", DbType.String, entity.MeterSize },
                new object[] { "@meter_number", DbType.String, entity.MeterNumber },
                new object[] { "@reading_before_test", DbType.String, entity.ReadingBeforeTest },
                new object[] { "@reading_after_test", DbType.String, entity.ReadingAfterTest },
                new object[] { "@calibration_result", DbType.String, entity.CalibrationResult },
                new object[] { "@has_adjustment", DbType.Boolean, entity.HasAdjustment },
                new object[] { "@leaking_after_the_meter", DbType.String, entity.LeakingAfterTheMeter },
                new object[] { "@investigated_by", DbType.String, entity.InvestigatedBy }
            };;

            string query = $@"UPDATE {tableName} 
                            SET job_orders_id = @job_orders_id, 
                                job_order_no = @job_order_no, 
                                customer_name = @customer_name, 
                                customer_address = @customer_address, 
                                account_number = @account_number, 
                                nature_of_complaint = @nature_of_complaint, 
                                date_of_investigation = @date_of_investigation, 
                                investigator_comments = @investigator_comments, 
                                recommendations = @recommendations, 
                                image_path = @image_path, 
                                secondary_image_path = @secondary_image_path, 
                                is_approved = @is_approved, 
                                approval_message = @approval_message, 
                                updated_by = @updated_by, 
                                immediate_members_of_fam = @immediate_members_of_fam, 
                                house_helper = @house_helper, 
                                relatives = @relatives, 
                                boarders = @boarders, 
                                no_of_hours_served = @no_of_hours_served, 
                                no_service_outlets = @no_service_outlets, 
                                hh_purpose = @hh_purpose, 
                                government = @government, 
                                promote_trade_business = @promote_trade_business, 
                                sell_to_neighbours = @sell_to_neighbours, 
                                alternative_source = @alternative_source, 
                                meter_brand = @meter_brand, 
                                meter_size = @meter_size, 
                                meter_number = @meter_number, 
                                reading_before_test = @reading_before_test, 
                                reading_after_test = @reading_after_test, 
                                calibration_result = @calibration_result, 
                                leaking_after_the_meter = @leaking_after_the_meter,
                                has_adjustment = @has_adjustment,
                                investigated_by = @investigated_by 
                            WHERE id = @id;";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public int GetLastInsertedId(int userId)
        {
            var parameters = new object[][]
            {  new object[] { "@user_id", DbType.Int32, userId}, };

            string query = $"SELECT MAX(id) FROM {tableName}";

            return int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public Dictionary<string, string> GetViewRecordById(int selectedId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, selectedId }
            };

            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            var dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count == 0)
            {
                return null;
            }

            var result = new Dictionary<string, string>();
            foreach (DataColumn column in dataTable.Columns)
            {
                result[column.ColumnName] = dataTable.Rows[0][column].ToString();
            }

            return result;
        }

        public Dictionary<string, string> GetViewRecordByJobOrderId(int? jobOrderId)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, string> GetViewRecordByJobOrderNo(string jobOrderNumber)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[] { "@jo_number", DbType.Int32, jobOrderNumber }
            };

            string query = $"SELECT * FROM {tableName} WHERE job_order_no = @jo_number";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }

        public DataTable GetViewRecordsBySearch(int statusId, string searchKey)
        {
            var parameters = new object[][] { new object[] { "@search_text", DbType.String, $"%{searchKey}%" }, };

            string statusQuery = string.Empty;

            if (statusId != 6)
            {
                switch (statusId)
                {
                    case 0:
                        statusQuery = "is_approved = 0 AND ";
                        break;
                    case 1:
                        statusQuery = "is_approved = 1 AND ";
                        break;
                    case 2:
                        statusQuery = "is_approved = 2 AND ";
                        break;
                    case 3:
                        statusQuery = "is_approved = 3 AND ";
                        break;
                    case 4:
                        statusQuery = "is_approved = 4 AND ";
                        break;
                    case 5:
                        statusQuery = "is_approved = 5 AND ";
                        break;
                    default:
                        statusQuery = string.Empty;
                        break;
                }
            }

            string query = $"SELECT id, job_orders_id, " +
                           $"CASE is_approved " +
                           $"WHEN 0 THEN 'FOR INVESTIGATION' " +
                           $"WHEN 1 THEN 'FOR RECOMMENDATION' " +
                           $"WHEN 2 THEN 'FOR ADJUSTMENT' " +
                           $"WHEN 3 THEN 'FOR APPROVAL' " +
                           $"WHEN 4 THEN 'APPROVED' " +
                           $"WHEN 5 THEN 'FOR REINVESTIGATION' " +
                           $"ELSE 'UNKNOWN' END AS approval_status, job_order_no, customer_name, account_number, customer_address, nature_of_complaint, date_of_investigation, created_at " +
                           $"FROM  {tableName} WHERE {statusQuery} (job_order_no  LIKE @search_text OR account_number  LIKE @search_text OR customer_name LIKE @search_text) ORDER BY created_at DESC LIMIT 100";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public DataTable GetViewRecordsBySearch(int statusId, int rowLimit, string searchKey)
        {
            var parameters = new object[][] { 
                new object[] { "@search_text", DbType.String, $"%{searchKey}%" },  
                new object[] { "@row_filter", DbType.Int32, rowLimit }, 
            
            };

            string rowFilterValue = rowLimit == 0 ? string.Empty : $" LIMIT @row_filter";
            string statusQuery = string.Empty;

            if (statusId != 6)
            {
                switch (statusId)
                {
                    case 0:
                        statusQuery = "is_approved = 0 AND ";
                        break;
                    case 1:
                        statusQuery = "is_approved = 1 AND ";
                        break;
                    case 2:
                        statusQuery = "is_approved = 2 AND ";
                        break;
                    case 3:
                        statusQuery = "is_approved = 3 AND ";
                        break;
                    case 4:
                        statusQuery = "is_approved = 4 AND ";
                        break;
                    case 5:
                        statusQuery = "is_approved = 5 AND ";
                        break;
                    default:
                        statusQuery = string.Empty;
                        break;
                }
            }

            string query = $"SELECT id, job_orders_id, " +
                           $"CASE is_approved " +
                           $"WHEN 0 THEN 'FOR INVESTIGATION' " +
                           $"WHEN 1 THEN 'FOR RECOMMENDATION' " +
                           $"WHEN 2 THEN 'FOR ADJUSTMENT' " +
                           $"WHEN 3 THEN 'FOR APPROVAL' " +
                           $"WHEN 4 THEN 'APPROVED' " +
                           $"WHEN 5 THEN 'FOR REINVESTIGATION' " +
                           $"ELSE 'UNKNOWN' END AS approval_status, job_order_no, customer_name, account_number, customer_address, nature_of_complaint, date_of_investigation, created_at " +
                           $"FROM  {tableName} WHERE {statusQuery} (job_order_no  LIKE @search_text OR account_number  LIKE @search_text OR customer_name LIKE @search_text) ORDER BY created_at DESC {rowFilterValue}";

            var dataTable = new DataTable();
            return mySqlGenericCommands.FillBySearch(query, dataTable, parameters);
        }

        public bool SaveComputation(InvestigationModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id },
                new object[] { "@reading_before_test", DbType.String, entity.ReadingBeforeTest },
                new object[] { "@reading_after_test", DbType.String, entity.ReadingAfterTest },
                new object[] { "@calibration_result", DbType.String, entity.CalibrationResult },
                new object[] { "@over_registration", DbType.String, entity.OverRegistration },
                new object[] { "@under_registration", DbType.String, entity.UnderRegistration },
                new object[] { "@leaking_after_the_meter", DbType.String, entity.LeakingAfterTheMeter },
                new object[] { "@previous_reading", DbType.String, entity.PreviousReading },
                new object[] { "@present_reading", DbType.String, entity.PresentReading },
                new object[] { "@actual_reading", DbType.String, entity.ActualReading },
                new object[] { "@present_consumption", DbType.String, entity.PresentConsumption },
                new object[] { "@previous_consumption", DbType.String, entity.PreviousConsumption },
                new object[] { "@actual_consumption", DbType.String, entity.ActualConsumption },
                new object[] { "@last_three_months_consumption", DbType.String, entity.AverageConsumption },
                new object[] { "@water_bill", DbType.String, entity.WaterBill },
                new object[] { "@water_bill_adjustment", DbType.String, entity.WaterBillAdjustment },
                new object[] { "@adjusted_water_bill", DbType.String, entity.AdjustedWaterBill },
                new object[] { "@extension_fee", DbType.String, entity.ExtensionFee },
                new object[] { "@penalty", DbType.String, entity.Penalty },
                new object[] { "@adjustment_particular", DbType.String, entity.AdjustmentParticular },
                new object[] { "@updated_by", DbType.String, entity.UpdatedBy },

             };

            string query = $@"UPDATE {tableName} 
                            SET reading_before_test = @reading_before_test, 
                                reading_after_test = @reading_after_test, 
                                calibration_result = @calibration_result, 
                                over_registration = @over_registration, 
                                under_registration = @under_registration, 
                                leaking_after_the_meter = @leaking_after_the_meter, 
                                previous_reading = @previous_reading, 
                                present_reading = @present_reading, 
                                actual_reading = @actual_reading, 
                                previous_consumption = @previous_consumption, 
                                present_consumption = @present_consumption, 
                                actual_consumption = @actual_consumption, 
                                last_three_months_consumption = @last_three_months_consumption,
                                water_bill = @water_bill,
                                water_bill_adjustment = @water_bill_adjustment, 
                                adjustment_particular = @adjustment_particular, 
                                adjusted_water_bill = @adjusted_water_bill, 
                                extension_fee = @extension_fee, 
                                penalty = @penalty, 
                                updated_by = @updated_by
                            WHERE id = @id;";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public int RecordCount()
        {
            string query = $"SELECT COUNT(*) FROM {tableName}";
            return int.Parse(mySqlGenericCommands.ExecuteScalar(query));
        }

        public bool InsertApprovalMessage(InvestigationModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.String,  entity.InvestigationId },
                new object[] { "@job_orders_id", DbType.Int32,  entity.JobOrderId },
                new object[] { "@approval_message", DbType.String, entity.ApprovalMessage },
            };

            string query = $"UPDATE {tableName} SET " +
                            $"approval_message = @approval_message " +
                            $"WHERE id = @id AND job_orders_id = @job_orders_id";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public string GetApprovalMessage(int investigationId)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, investigationId }
            };
            string query = $"SELECT approval_message FROM {tableName} WHERE id = @id";
            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);
            if (dataTable.Rows.Count > 0)
            {
                return dataTable.Rows[0]["approval_message"].ToString();
            }
            return string.Empty;
        }

        public bool UpdateStatus(int jobOrderId, int statusId)
        {
            var parameters = new object[][]
            {
                new object[] { "@job_order_id", DbType.Int32, jobOrderId},
                new object[] { "@status_id", DbType.Int32, statusId},
            };

            string query = $"UPDATE {tableName} SET status_id = @status_id WHERE id = @job_order_id";
            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public int GetInvestigationIdByJOID(int jobOrderId)
        {
            var parameters = new object[][]
            {  new object[] { "@job_orders_id", DbType.Int32, jobOrderId}, };

            string query = $"SELECT id FROM {tableName} WHERE job_orders_id = @job_orders_id";

            return int.Parse(mySqlGenericCommands.ExecuteScalar(query, parameters));
        }

        public bool UpdateImage(InvestigationModel entity)
        {
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, entity.Id },
                new object[] { "@image_path", DbType.String, entity.ImagePath },
                new object[] { "@secondary_image_path", DbType.String, entity.SecondaryImagePath },
            }; 

            string query = $@"UPDATE {tableName} 
                            SET 
                                image_path = @image_path, 
                                secondary_image_path = @secondary_image_path 
                            WHERE id = @id";

            return mySqlGenericCommands.ExecuteNonQuery(query, parameters);
        }

        public Dictionary<string, string> GetImagePathByInvestigationId(int investigationId)
        {
            var recordDictionary = new Dictionary<string, string>();
            var parameters = new object[][]
            {
                new object[] { "@id", DbType.Int32, investigationId }
            };

            string query = $"SELECT image_path, secondary_image_path FROM {tableName} WHERE id = @id";

            DataTable dataTable = mySqlGenericCommands.ExecuteReader(query, parameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                foreach (DataColumn column in dataTable.Columns)
                    recordDictionary[column.ColumnName] = row[column].ToString();

                return recordDictionary;
            }
            return recordDictionary;
        }
    }
}