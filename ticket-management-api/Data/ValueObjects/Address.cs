using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ticket_management_api.Data.ValueObjects;

public record Address(string Street1, string Village, string Baranggay, string City, string Province, string Country, string PostalCode, string? LandMarks, string? Coordinates);
