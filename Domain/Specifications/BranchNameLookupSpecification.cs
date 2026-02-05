using Ardalis.Specification;
using Domain.Entities;

namespace Domain.Specifications
{
    public class BranchNameLookupSpecification : Specification<Branch>
    {
        public BranchNameLookupSpecification(string branchName)
        {
            Query.Where(e => e.BranchIDInfo.Name.ToLower() == branchName.ToLower());
        }
        public BranchNameLookupSpecification(string branchName, string excludedBranchId)
        {
            Query.Where(e => e.BranchIDInfo.Name.ToLower() == branchName.ToLower() && e.Id != excludedBranchId);
        }
    }
}
