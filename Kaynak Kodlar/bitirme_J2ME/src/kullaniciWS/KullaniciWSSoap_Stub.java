// This class was generated by 172 StubGenerator.
// Contents subject to change without notice.
// @generated

package kullaniciWS;

import javax.xml.rpc.JAXRPCException;
import javax.xml.namespace.QName;
import javax.microedition.xml.rpc.Operation;
import javax.microedition.xml.rpc.Type;
import javax.microedition.xml.rpc.ComplexType;
import javax.microedition.xml.rpc.Element;

public class KullaniciWSSoap_Stub implements kullaniciWS.KullaniciWSSoap, javax.xml.rpc.Stub {
	private String[] _propertyNames;
	private Object[] _propertyValues;

	public KullaniciWSSoap_Stub() {
		_propertyNames = new String[] {ENDPOINT_ADDRESS_PROPERTY};
		_propertyValues = new Object[] {"http://160.75.96.32/1/webServices/kullaniciWS.asmx"};
	}

	public void _setProperty(String name, Object value) {
		int size = _propertyNames.length;
		for (int i = 0; i < size; ++i) {
			if (_propertyNames[i].equals(name)) {
				_propertyValues[i] = value;
				return;
			}
		}
		// Need to expand our array for a new property
		String[] newPropNames = new String[size + 1];
		System.arraycopy(_propertyNames, 0, newPropNames, 0, size);
		_propertyNames = newPropNames;
		Object[] newPropValues = new Object[size + 1];
		System.arraycopy(_propertyValues, 0, newPropValues, 0, size);
		_propertyValues = newPropValues;

		_propertyNames[size] = name;
		_propertyValues[size] = value;
	}

	public Object _getProperty(String name) {
		for (int i = 0; i < _propertyNames.length; ++i) {
			if (_propertyNames[i].equals(name)) {
				return _propertyValues[i];
			}
		}
		if (ENDPOINT_ADDRESS_PROPERTY.equals(name) || USERNAME_PROPERTY.equals(name) || PASSWORD_PROPERTY.equals(name)) {
			return null;
		}
		if (SESSION_MAINTAIN_PROPERTY.equals(name)) {
			return new java.lang.Boolean(false);
		}
		throw new JAXRPCException("Stub does not recognize property: "+name);
	}

	protected void _prepOperation(Operation op) {
		for (int i = 0; i < _propertyNames.length; ++i) {
			op.setProperty(_propertyNames[i], _propertyValues[i].toString());
		}
	}

	// 
	//  Begin user methods
	// 

	public boolean giris(java.lang.String isim, java.lang.String sifre) throws java.rmi.RemoteException {
		// Copy the incoming values into an Object array if needed.
		Object[] inputObject = new Object[2];
		inputObject[0] = isim;
		inputObject[1] = sifre;

		Operation op = Operation.newInstance(_qname_giris, _type_giris, _type_girisResponse);
		_prepOperation(op);
		op.setProperty(Operation.SOAPACTION_URI_PROPERTY, "http://localhost/kullaniciWS/giris");
		Object resultObj;
		try {
			resultObj = op.invoke(inputObject);
		} catch (JAXRPCException e) {
			Throwable cause = e.getLinkedCause();
			if (cause instanceof java.rmi.RemoteException) {
				throw (java.rmi.RemoteException) cause;
			}
			throw e;
		}
		boolean result;
		// Convert the result into the right Java type.
		// Unwrapped return value
		Object girisResultObj = ((Object[])resultObj)[0];
		result = ((java.lang.Boolean)girisResultObj).booleanValue();
		return result;
	}

	public long idGetir(java.lang.String isim) throws java.rmi.RemoteException {
		// Copy the incoming values into an Object array if needed.
		Object[] inputObject = new Object[1];
		inputObject[0] = isim;

		Operation op = Operation.newInstance(_qname_idGetir, _type_idGetir, _type_idGetirResponse);
		_prepOperation(op);
		op.setProperty(Operation.SOAPACTION_URI_PROPERTY, "http://localhost/kullaniciWS/idGetir");
		Object resultObj;
		try {
			resultObj = op.invoke(inputObject);
		} catch (JAXRPCException e) {
			Throwable cause = e.getLinkedCause();
			if (cause instanceof java.rmi.RemoteException) {
				throw (java.rmi.RemoteException) cause;
			}
			throw e;
		}
		long result;
		// Convert the result into the right Java type.
		// Unwrapped return value
		Object idGetirResultObj = ((Object[])resultObj)[0];
		result = ((java.lang.Long)idGetirResultObj).longValue();
		return result;
	}

	public java.lang.String tipGetir(java.lang.String isim) throws java.rmi.RemoteException {
		// Copy the incoming values into an Object array if needed.
		Object[] inputObject = new Object[1];
		inputObject[0] = isim;

		Operation op = Operation.newInstance(_qname_tipGetir, _type_tipGetir, _type_tipGetirResponse);
		_prepOperation(op);
		op.setProperty(Operation.SOAPACTION_URI_PROPERTY, "http://localhost/kullaniciWS/tipGetir");
		Object resultObj;
		try {
			resultObj = op.invoke(inputObject);
		} catch (JAXRPCException e) {
			Throwable cause = e.getLinkedCause();
			if (cause instanceof java.rmi.RemoteException) {
				throw (java.rmi.RemoteException) cause;
			}
			throw e;
		}
		java.lang.String result;
		// Convert the result into the right Java type.
		// Unwrapped return value
		Object tipGetirResultObj = ((Object[])resultObj)[0];
		result = (java.lang.String)tipGetirResultObj;
		return result;
	}
	// 
	//  End user methods
	// 

	protected static final QName _qname_giris = new QName("http://localhost/kullaniciWS/", "giris");
	protected static final QName _qname_girisResponse = new QName("http://localhost/kullaniciWS/", "girisResponse");
	protected static final QName _qname_girisResult = new QName("http://localhost/kullaniciWS/", "girisResult");
	protected static final QName _qname_idGetir = new QName("http://localhost/kullaniciWS/", "idGetir");
	protected static final QName _qname_idGetirResponse = new QName("http://localhost/kullaniciWS/", "idGetirResponse");
	protected static final QName _qname_idGetirResult = new QName("http://localhost/kullaniciWS/", "idGetirResult");
	protected static final QName _qname_isim = new QName("http://localhost/kullaniciWS/", "isim");
	protected static final QName _qname_sifre = new QName("http://localhost/kullaniciWS/", "sifre");
	protected static final QName _qname_tipGetir = new QName("http://localhost/kullaniciWS/", "tipGetir");
	protected static final QName _qname_tipGetirResponse = new QName("http://localhost/kullaniciWS/", "tipGetirResponse");
	protected static final QName _qname_tipGetirResult = new QName("http://localhost/kullaniciWS/", "tipGetirResult");
	protected static final Element _type_giris;
	protected static final Element _type_girisResponse;
	protected static final Element _type_idGetir;
	protected static final Element _type_idGetirResponse;
	protected static final Element _type_tipGetir;
	protected static final Element _type_tipGetirResponse;
	static {
		// Create all of the Type's that this stub uses, once.
		Element _type_isim;
		_type_isim = new Element(_qname_isim, Type.STRING, 0, 1, false);
		Element _type_sifre;
		_type_sifre = new Element(_qname_sifre, Type.STRING, 0, 1, false);
		ComplexType _complexType_giris;
		_complexType_giris = new ComplexType();
		_complexType_giris.elements = new Element[2];
		_complexType_giris.elements[0] = _type_isim;
		_complexType_giris.elements[1] = _type_sifre;
		_type_giris = new Element(_qname_giris, _complexType_giris);
		Element _type_girisResult;
		_type_girisResult = new Element(_qname_girisResult, Type.BOOLEAN);
		ComplexType _complexType_girisResponse;
		_complexType_girisResponse = new ComplexType();
		_complexType_girisResponse.elements = new Element[1];
		_complexType_girisResponse.elements[0] = _type_girisResult;
		_type_girisResponse = new Element(_qname_girisResponse, _complexType_girisResponse);
		ComplexType _complexType_idGetir;
		_complexType_idGetir = new ComplexType();
		_complexType_idGetir.elements = new Element[1];
		_complexType_idGetir.elements[0] = _type_isim;
		_type_idGetir = new Element(_qname_idGetir, _complexType_idGetir);
		Element _type_idGetirResult;
		_type_idGetirResult = new Element(_qname_idGetirResult, Type.LONG);
		ComplexType _complexType_idGetirResponse;
		_complexType_idGetirResponse = new ComplexType();
		_complexType_idGetirResponse.elements = new Element[1];
		_complexType_idGetirResponse.elements[0] = _type_idGetirResult;
		_type_idGetirResponse = new Element(_qname_idGetirResponse, _complexType_idGetirResponse);
		_type_tipGetir = new Element(_qname_tipGetir, _complexType_idGetir);
		Element _type_tipGetirResult;
		_type_tipGetirResult = new Element(_qname_tipGetirResult, Type.STRING, 0, 1, false);
		ComplexType _complexType_tipGetirResponse;
		_complexType_tipGetirResponse = new ComplexType();
		_complexType_tipGetirResponse.elements = new Element[1];
		_complexType_tipGetirResponse.elements[0] = _type_tipGetirResult;
		_type_tipGetirResponse = new Element(_qname_tipGetirResponse, _complexType_tipGetirResponse);
	}

}
