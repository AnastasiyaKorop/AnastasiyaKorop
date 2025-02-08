namespace BiometricAuthApp.Models
{
    public class BiometricData
    {
        public int Id { get; set; }
        public string DataType { get; set; }
        public string Parameters { get; set; }
        public byte[] EncryptedData { get; set; }
        public int EmployeeId { get; set; }
    }
}