
public class Address {
	
	public String street;
	public String city;
	public String province;
	public String postalCode;
	
	public Address () {
		street = "Rob street";
		city = "Rob city";
		province = "Rob province";
		postalCode = "Rob postalcode";
	}

	
	public String getStreet() {
		return street;
	}
	
	public String getCity() {
		return city;
	}
	
	public String getProvince() {
		return province;
	}
	
	public String getPostalCode() {
		return postalCode;
	}

}
