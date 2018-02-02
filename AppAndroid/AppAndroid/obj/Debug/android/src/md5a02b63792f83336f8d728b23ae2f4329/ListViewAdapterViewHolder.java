package md5a02b63792f83336f8d728b23ae2f4329;


public class ListViewAdapterViewHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_toString:()Ljava/lang/String;:GetToStringHandler\n" +
			"";
		mono.android.Runtime.register ("AppAndroid.ListViewAdapterViewHolder, AppAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ListViewAdapterViewHolder.class, __md_methods);
	}


	public ListViewAdapterViewHolder ()
	{
		super ();
		if (getClass () == ListViewAdapterViewHolder.class)
			mono.android.TypeManager.Activate ("AppAndroid.ListViewAdapterViewHolder, AppAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public java.lang.String toString ()
	{
		return n_toString ();
	}

	private native java.lang.String n_toString ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
