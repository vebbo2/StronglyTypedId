namespace StronglyTypedId
{
    [StronglyTypedId(backingType: StronglyTypedIdBackingType.Long)]
    partial struct LongId { }

    [StronglyTypedId(generateJsonConverter: false, backingType: StronglyTypedIdBackingType.Long)]
    partial struct NoJsonLongId { }
}