package md50dd8f2652d8b7e9abf60791ffb49a0cd;


public class TakePictureFragment
	extends md50dd8f2652d8b7e9abf60791ffb49a0cd.CustomDialogActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ApplikasjonBoknaden.Droid.DialogFragments.TakePictureFragment, ApplikasjonBoknaden.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", TakePictureFragment.class, __md_methods);
	}


	public TakePictureFragment () throws java.lang.Throwable
	{
		super ();
		if (getClass () == TakePictureFragment.class)
			mono.android.TypeManager.Activate ("ApplikasjonBoknaden.Droid.DialogFragments.TakePictureFragment, ApplikasjonBoknaden.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
