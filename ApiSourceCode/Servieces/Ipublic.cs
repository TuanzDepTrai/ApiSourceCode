using ApiSourceCode.Models.Domain;


namespace ApiSourceCode.Servieces
{
    public interface Ipublic
    {
        public List<PublicDTO> Getall { get; set; }

        public PublicDTO GetPublic(int id);
        public PublicDTO AddPublic(PublicDTO Public);
        public void DeletePublic(int id);
        public PublicDTO UpdatePublic(PublicDTO Public);
    }
}
