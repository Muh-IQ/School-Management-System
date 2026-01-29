# Use Case: Create School (Tenant)

**Actor:** 
- Super Admin

**Description:**  
The Super Admin creates a new school (tenant) in the system, which will have an independent identity, isolated data, and default administrative settings.

**Preconditions:**  
- Super Admin is logged in successfully.
- Basic school information is ready (school name, contact information, optional settings).

**Main Flow || Happy Path:**  
1. Super Admin selects "Create School".  
2. System displays the school information form.  
3. Super Admin fills in the required info:  
   - School name
   - Contact information
   - Optional initial settings (language, time zone, policies)
4. System creates a new tenant context.  
5. System initializes isolated data storage.  
6. System checks if any optional settings were not provided and applies default school settings:
    - Language
    - Time zone
    - Policies
7. System confirms creation.

**Alternate Path:**
- If phone or email already exists:  
  1. System shows an error message.  
  2. Super Admin updates info.  
  3. Continue with Main Flow from step 4.

**Postconditions:**  
- School exists and is ready for assigning School Admin.  
- Data is isolated.  

**Related Modules:**  
- School & Tenant Management

**Notes**  
- The default school settings (Language and Time Zone) will be determined based on the request sender's location or settings.
- No user linked yet.
- All future operations require school to exist.