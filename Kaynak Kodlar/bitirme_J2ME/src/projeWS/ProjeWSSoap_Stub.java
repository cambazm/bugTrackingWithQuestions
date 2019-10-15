// This class was generated by 172 StubGenerator.
// Contents subject to change without notice.
// @generated

package projeWS;

import javax.xml.rpc.JAXRPCException;
import javax.xml.namespace.QName;
import javax.microedition.xml.rpc.Operation;
import javax.microedition.xml.rpc.Type;
import javax.microedition.xml.rpc.ComplexType;
import javax.microedition.xml.rpc.Element;

public class ProjeWSSoap_Stub implements projeWS.ProjeWSSoap, javax.xml.rpc.Stub {
	private String[] _propertyNames;
	private Object[] _propertyValues;

	public ProjeWSSoap_Stub() {
		_propertyNames = new String[] {ENDPOINT_ADDRESS_PROPERTY};
		_propertyValues = new Object[] {"http://160.75.96.32/1/webServices/projeWS.asmx"};
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

	public projeWS.ArrayOfString projeleriListele() throws java.rmi.RemoteException {
		// Copy the incoming values into an Object array if needed.
		Object[] inputObject = new Object[0];

		Operation op = Operation.newInstance(_qname_projeleriListele, _type_projeleriListele, _type_projeleriListeleResponse);
		_prepOperation(op);
		op.setProperty(Operation.SOAPACTION_URI_PROPERTY, "http://localhost/projeWS/projeleriListele");
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
		projeWS.ArrayOfString result;
		// Convert the result into the right Java type.
		// Unwrapped return value
		Object[] projeleriListeleResultObj = (Object[]) ((Object[])resultObj)[0];
		if (projeleriListeleResultObj == null) {
			result = null;
		} else {
			result = new projeWS.ArrayOfString();
			java.lang.String[] stringArray;
			Object stringObj = projeleriListeleResultObj[0];
			stringArray = (java.lang.String[]) stringObj;
			result.setString(stringArray);
		}
		return result;
	}

	public long projeyeAitCozulmemisHataSayisi(java.lang.String projeIsmi) throws java.rmi.RemoteException {
		// Copy the incoming values into an Object array if needed.
		Object[] inputObject = new Object[1];
		inputObject[0] = projeIsmi;

		Operation op = Operation.newInstance(_qname_projeyeAitCozulmemisHataSayisi, _type_projeyeAitCozulmemisHataSayisi, _type_projeyeAitCozulmemisHataSayisiResponse);
		_prepOperation(op);
		op.setProperty(Operation.SOAPACTION_URI_PROPERTY, "http://localhost/projeWS/projeyeAitCozulmemisHataSayisi");
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
		Object projeyeAitCozulmemisHataSayisiResultObj = ((Object[])resultObj)[0];
		result = ((java.lang.Long)projeyeAitCozulmemisHataSayisiResultObj).longValue();
		return result;
	}
	// 
	//  End user methods
	// 

	protected static final QName _qname_projeIsmi = new QName("http://localhost/projeWS/", "projeIsmi");
	protected static final QName _qname_projeleriListele = new QName("http://localhost/projeWS/", "projeleriListele");
	protected static final QName _qname_projeleriListeleResponse = new QName("http://localhost/projeWS/", "projeleriListeleResponse");
	protected static final QName _qname_projeleriListeleResult = new QName("http://localhost/projeWS/", "projeleriListeleResult");
	protected static final QName _qname_projeyeAitCozulmemisHataSayisi = new QName("http://localhost/projeWS/", "projeyeAitCozulmemisHataSayisi");
	protected static final QName _qname_projeyeAitCozulmemisHataSayisiResponse = new QName("http://localhost/projeWS/", "projeyeAitCozulmemisHataSayisiResponse");
	protected static final QName _qname_projeyeAitCozulmemisHataSayisiResult = new QName("http://localhost/projeWS/", "projeyeAitCozulmemisHataSayisiResult");
	protected static final QName _qname_string = new QName("http://localhost/projeWS/", "string");
	protected static final Element _type_projeleriListele;
	protected static final Element _type_projeleriListeleResponse;
	protected static final Element _type_projeyeAitCozulmemisHataSayisi;
	protected static final Element _type_projeyeAitCozulmemisHataSayisiResponse;
	static {
		// Create all of the Type's that this stub uses, once.
		ComplexType _complexType_projeleriListele;
		_complexType_projeleriListele = new ComplexType();
		_complexType_projeleriListele.elements = new Element[0];
		_type_projeleriListele = new Element(_qname_projeleriListele, _complexType_projeleriListele);
		Element _type_string;
		_type_string = new Element(_qname_string, Type.STRING, 0, -1, true);
		ComplexType _complexType_arrayOfString;
		_complexType_arrayOfString = new ComplexType();
		_complexType_arrayOfString.elements = new Element[1];
		_complexType_arrayOfString.elements[0] = _type_string;
		Element _type_projeleriListeleResult;
		_type_projeleriListeleResult = new Element(_qname_projeleriListeleResult, _complexType_arrayOfString, 0, 1, false);
		ComplexType _complexType_projeleriListeleResponse;
		_complexType_projeleriListeleResponse = new ComplexType();
		_complexType_projeleriListeleResponse.elements = new Element[1];
		_complexType_projeleriListeleResponse.elements[0] = _type_projeleriListeleResult;
		_type_projeleriListeleResponse = new Element(_qname_projeleriListeleResponse, _complexType_projeleriListeleResponse);
		Element _type_projeIsmi;
		_type_projeIsmi = new Element(_qname_projeIsmi, Type.STRING, 0, 1, false);
		ComplexType _complexType_projeyeAitCozulmemisHataSayisi;
		_complexType_projeyeAitCozulmemisHataSayisi = new ComplexType();
		_complexType_projeyeAitCozulmemisHataSayisi.elements = new Element[1];
		_complexType_projeyeAitCozulmemisHataSayisi.elements[0] = _type_projeIsmi;
		_type_projeyeAitCozulmemisHataSayisi = new Element(_qname_projeyeAitCozulmemisHataSayisi, _complexType_projeyeAitCozulmemisHataSayisi);
		Element _type_projeyeAitCozulmemisHataSayisiResult;
		_type_projeyeAitCozulmemisHataSayisiResult = new Element(_qname_projeyeAitCozulmemisHataSayisiResult, Type.LONG);
		ComplexType _complexType_projeyeAitCozulmemisHataSayisiResponse;
		_complexType_projeyeAitCozulmemisHataSayisiResponse = new ComplexType();
		_complexType_projeyeAitCozulmemisHataSayisiResponse.elements = new Element[1];
		_complexType_projeyeAitCozulmemisHataSayisiResponse.elements[0] = _type_projeyeAitCozulmemisHataSayisiResult;
		_type_projeyeAitCozulmemisHataSayisiResponse = new Element(_qname_projeyeAitCozulmemisHataSayisiResponse, _complexType_projeyeAitCozulmemisHataSayisiResponse);
	}

}
