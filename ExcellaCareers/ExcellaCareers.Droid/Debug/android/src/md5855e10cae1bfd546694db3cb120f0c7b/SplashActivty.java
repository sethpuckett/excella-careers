package md5855e10cae1bfd546694db3cb120f0c7b;


public class SplashActivty
	extends android.support.v7.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onResume:()V:GetOnResumeHandler\n" +
			"";
		mono.android.Runtime.register ("ExcellaCareers.Droid.Activities.SplashActivty, ExcellaCareers.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SplashActivty.class, __md_methods);
	}


	public SplashActivty () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SplashActivty.class)
			mono.android.TypeManager.Activate ("ExcellaCareers.Droid.Activities.SplashActivty, ExcellaCareers.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();

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
