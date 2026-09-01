using EduCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduCore.Infrastructure.Persistence.Configurations;

public class CourseCategoryConfiguration : IEntityTypeConfiguration<CourseCategory>
{
    public void Configure(EntityTypeBuilder<CourseCategory> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.NameEn).IsRequired().HasMaxLength(100);
        builder.Property(c => c.NameAr).IsRequired().HasMaxLength(100);

        builder.HasData(
            new CourseCategory
            {
                Id = Guid.Parse("7b2e3c1a-9d4f-4a3b-8c2e-1a2b3c4d5e6f"),
                NameEn = "Development & Programming",
                NameAr = "التطوير والبرمجة"
            },
            new CourseCategory
            {
                Id = Guid.Parse("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d"),
                NameEn = "Artificial Intelligence & Data Science",
                NameAr = "الذكاء الاصطناعي وعلوم البيانات"
            },
            new CourseCategory
            {
                Id = Guid.Parse("8f7e6d5c-4b3a-2109-8765-43210fedcba9"),
                NameEn = "Business & Entrepreneurship",
                NameAr = "الأعمال وريادة الأعمال"
            },
            new CourseCategory
            {
                Id = Guid.Parse("bcde1234-5678-90ab-cdef-1234567890ab"),
                NameEn = "Design & User Experience (UX)",
                NameAr = "التصميم وتجربة المستخدم"
            },
            new CourseCategory
            {
                Id = Guid.Parse("f4e3d2c1-b0a9-8765-4321-fedcba987654"),
                NameEn = "Cybersecurity & IT Operations",
                NameAr = "الأمن السيبراني وتقنية المعلومات"
            },
            new CourseCategory
            {
                Id = Guid.Parse("22334455-6677-8899-00aa-bbccddeeff00"),
                NameEn = "Marketing & Digital Strategy",
                NameAr = "التسويق والاستراتيجية الرقمية"
            },
            new CourseCategory
            {
                Id = Guid.Parse("aabbccdd-eeff-1122-3344-556677889900"),
                NameEn = "Personal Development & Soft Skills",
                NameAr = "تطوير الذات والمهارات الشخصية"
            },
            new CourseCategory
            {
                Id = Guid.Parse("55667788-9900-aabb-ccdd-eeff11223344"),
                NameEn = "Health, Fitness & Wellness",
                NameAr = "الصحة واللياقة البدنية"
            }
        );
    }
}
