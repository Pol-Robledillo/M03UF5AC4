namespace M03UF5AC3.persistence.DAO
{
    public interface IConsumDAO
    {
        ConsumDTO GetConsumByID(int id);
        public List<ConsumDTO> GetAll();
        public void Insert(ConsumDTO consum);
        public void Update(ConsumDTO consum);
        public void Delete(ConsumDTO consum);
    }
}
