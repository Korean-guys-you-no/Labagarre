using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;
using UnityEngine;

namespace JoyConUnity
{
	public class JoyConManager : MonoBehaviour
	{
		private static JoyConManager _instance;
		public static JoyConManager Instance => _instance;
		
		// Settings accessible via Unity
		public bool EnableIMU = true;
		public bool EnableLocalize = true;

		// Different operating systems either do or don't like the trailing zero
		private const ushort VendorId = 0x57e;
		private const ushort VendorIdWithTrailingZero = 0x057e;
		private const ushort LeftJoyConId = 0x2006;
		private const ushort RightJoyConId = 0x2007;

		private List<JoyCon> _connectedJoyCons = new List<JoyCon>();

		public JoyCon LeftController => _connectedJoyCons.Count > 0 ? _connectedJoyCons[0] : null;
		public JoyCon RightController => _connectedJoyCons.Count > 1 ? _connectedJoyCons[1] : null;
		
		private void Awake()
		{
			Scan();
		}

		private void Start()
		{
			for (int i = 0; i < _connectedJoyCons.Count; ++i)
			{
				Debug.Log(i);
				JoyCon jc = _connectedJoyCons[i];
				byte LEDs = 0x0;
				LEDs |= (byte)(0x1 << i);
				jc.Attach(leds_: LEDs);
				jc.Begin();
			}
		}

		internal void OnApplicationQuit()
		{
			for (int i = 0; i < _connectedJoyCons.Count; ++i)
			{
				JoyCon jc = _connectedJoyCons[i];
				jc.Detach();
			}
		}
                                   
		private void Update()                
		{      
			UpdateJoyConsState();
		}

		private void UpdateJoyConsState()
		{                                     
			foreach (var jc in _connectedJoyCons)             
				jc.Update();
		}
		
		#region NonUnityMagic

		private void Scan()
		{
			if (_instance != null) ;
			_instance = this;
			int i = 0;


			bool isLeft = false;
			HIDapi.hid_init();

			IntPtr ptr = HIDapi.hid_enumerate(VendorId, 0x0);
			IntPtr topPtr = ptr;

			if (ptr == IntPtr.Zero)
			{
				ptr = HIDapi.hid_enumerate(VendorIdWithTrailingZero, 0x0);
				if (ptr == IntPtr.Zero)
				{
					HIDapi.hid_free_enumeration(ptr);
					Debug.Log("No Joy-Cons found!");
				}
			}
			
			while (ptr != IntPtr.Zero) {
				var enumerate = (hid_device_info)Marshal.PtrToStructure(ptr, typeof(hid_device_info));
				var isValid = false;
				Debug.Log(enumerate.product_id);
				if (enumerate.product_id == LeftJoyConId || enumerate.product_id == RightJoyConId) {
					if (enumerate.product_id == LeftJoyConId) {
						isValid = true;
						isLeft = true;
						Debug.Log("Left Joy-Con connected.");
					} else if (enumerate.product_id == RightJoyConId) {
						isValid = true;
						isLeft = false;
						Debug.Log("Right Joy-Con connected.");
					} else {
						Debug.Log("Non Joy-Con input device skipped.");
					}
					if (isValid)
					{
						IntPtr handle = HIDapi.hid_open_path(enumerate.path);
						HIDapi.hid_set_nonblocking(handle, 1);
						_connectedJoyCons.Add(new JoyCon(handle, EnableIMU, EnableLocalize & EnableIMU, 0.04f, isLeft));
					}
					++i;
				}
				ptr = enumerate.next;
			}
			HIDapi.hid_free_enumeration(topPtr);
		}
		
		#endregion
	}
}