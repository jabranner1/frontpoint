using Frontpoint.UseCases.Individuals;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Frontpoint.Server.Models;

public class IndividualViewModel
{
    public IndividualViewModel() { }

    [SetsRequiredMembers]
    public IndividualViewModel(
        int id,
        string? prefix,
        string firstName,
        string? middleName,
        string lastName,
        DateTime dateOfBirth,
        string telephoneNumber,
        string addressLine1,
        string? addressLine2,
        string city,
        string state,
        string zip,
        string country)
    {
        Id = id;
        Prefix = prefix;
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        TelephoneNumber = telephoneNumber;
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        City = city;
        State = state;
        Zip = zip;
        Country = country;
    }

    public int? Id { get; set; }

    [MaxLength(25)]
    public string? Prefix { get; set; }

    [Required, MaxLength(100)]
    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    [Required, MaxLength(100)]
    public string? LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    [Required, MaxLength(100)]
    public string? TelephoneNumber { get; set; }

    [Required, MaxLength(100)]
    public string? AddressLine1 { get; set; }

    [MaxLength(100)]
    public string? AddressLine2 { get; set; }

    [Required, MaxLength(50)]
    public string? City { get; set; }

    [Required, MaxLength(50)]
    public string? State { get; set; }

    [Required, MaxLength(15)]
    public string? Zip { get; set; }

    [Required, MaxLength(50)]
    public string? Country { get; set; }

    /// <summary>
    /// Maps viewmodel to dto
    /// </summary>
    /// <param name="individaul"></param>
    /// <returns></returns>
    public static IndividualDto ToDto(IndividualViewModel individaul)
    {
        return new IndividualDto(
            individaul.Id ?? -1,
            individaul.Prefix,
            individaul.FirstName,
            individaul.MiddleName,
            individaul.LastName,
            DateOnly.FromDateTime(individaul.DateOfBirth),
            individaul.TelephoneNumber,
            individaul.AddressLine1,
            individaul.AddressLine2,
            individaul.City,
            individaul.State,
            individaul.Zip,
            individaul.Country);
    }

    /// <summary>
    /// Maps dto to viewmodel
    /// </summary>
    /// <param name="individual"></param>
    /// <returns></returns>
    public static IndividualViewModel FromDto(IndividualDto individual)
    {
        return new IndividualViewModel(
           individual.Id,
           individual.Prefix,
           individual.FirstName,
           individual.MiddleName,
           individual.LastName,
           individual.DateOfBirth.ToDateTime(new TimeOnly()),
           individual.TelephoneNumber,
           individual.AddressLine1,
           individual.AddressLine2,
           individual.City,
           individual.State,
           individual.Zip,
           individual.Country);
    }
}
