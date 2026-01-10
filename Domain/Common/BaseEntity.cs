namespace Domain.Common
{
    public abstract class BaseEntity
    {
        // GUID kullanımı dağıtık sistemlerde benzersiz kimlikler oluşturmak için idealdir. Daha güvenli ve çakışma riski daha düşüktür.
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid(); // Yeni bir GUID oluşturur ve varsayılan olarak atar. Veri tabanının otomatik olarak atamasını istersek sıralı olma ihtimali var, bu yüzden burada atıyoruz.
            CreatedAt = DateTime.UtcNow; // Oluşturulma tarihini UTC olarak ayarlar. UTC kullanımı zaman dilimi sorunlarını önler.
        }

        protected void MarkAsUpdated()
        {
            UpdatedAt = DateTime.UtcNow; // Güncellenme tarihini UTC olarak ayarlar.
        }

        // Equals override edilere '==' operatörünün doğru çalışması sağlanır.
        public override bool Equals(object? obj)
        {
            if (obj is not BaseEntity other)
                return false;

            //ReferenceEquals: İki nesnenin aynı referansa sahip olup olmadığını kontrol eder.
            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return Id == other.Id;
        }

        // Burada nesnenin tüm hash kodu yerine sadece Id'nin hash kodu kullanılır. Bu, nesnenin kimliğine dayalı olarak tutarlı bir hash kodu sağlar.
        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(BaseEntity? left, BaseEntity? right)
        {
            if (left is null && right is null)
                return true;
            if (left is null || right is null)
                return false;
            return left.Equals(right);
        }

        public static bool operator !=(BaseEntity? left, BaseEntity? right) => !(left == right);
    }
}
