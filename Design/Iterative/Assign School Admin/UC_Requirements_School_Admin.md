# Use Case: Assign School Admin

**Actor:** 
- Super Admin
**Description:**  
The Super Admin Assign a new school to school Admin in the system

**Preconditions:**  
- Super Admin is logged in successfully.
- School is Created and ready for assigning
- Basic schoolAdmin information is ready (name,contact information,DOB).

**Main Flow || Happy Path:**  
1. Super Admin selects school  
2. System displays the school information.  
3. Super admin press assign to schoolAdmin
4. Super Admin fills in the required info:  
   - name school Admin
   - Contact information school Admin
   -Gender
   -startDate
   -EndDate
   - DOB
5. System confirm assign succusefully.

**Alternate Path:**
- If school already assign: 
  1. System shows an error message.  
- If phone or email already exists:  
  1. System shows an error message   
  2. Super Admin updates info.  
  3. Continue with Main Flow from step5.

**Postconditions:**  
- School is successfully assigning to School Admin.
**Related Modules:**  
- School & Tenant Management
