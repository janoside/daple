using System;
using System.Runtime.InteropServices;

namespace Daple.Animation {

	/// <summary>
	/// A very accurate game timer.
	/// </summary>
	public class DXTimer {

		#region Functions

		/// <summary>
		/// This function retrieves the system's performance 
		/// counter frequency.
		/// </summary>
		[DllImport("kernel32")]
		private static extern bool QueryPerformanceFrequency(ref long Frequency);

		/// <summary>
		/// This function retrieves the current number of
		/// ticks for this system.
		/// </summary>
		[DllImport("kernel32")]
		private static extern bool QueryPerformanceCounter(ref long Count);

		#endregion

		#region Fields

		//last number of ticks
		private long fLastTime = 0;

		//current number of ticks
		private long fCurrentTime = 0;

		//the number of ticks per second for this system
		//(this should be a constant value)
		public long fTicksPerSecond = 0;

		//indicates if the timer is initialized
		private bool fInitialized = false;

		//elapsed seconds since the last GetElapsedSeconds() call
		private double fElapsedSeconds = 0.0;

		//elapsed seconds since the last GetElapsedMilliseconds() call
		private double fElapsedMilliseconds = 0.0;

		#endregion

		public DXTimer() {
		}

		#region Methods

		/// <summary>
		/// Timer initialization method.  Tries to query performance
		/// frequency and throws an exception if performance counters \
		/// aren't supported by this system.
		/// </summary>
		public void Init() {
			//try to read the frequency
			if ( !QueryPerformanceFrequency(ref fTicksPerSecond) ) {
				throw new Exception("Performance counters not supported on this system");
			}

			//Initilization successful
			this.fInitialized = true;
		}

		/// <summary>
		/// Starts the timer.  This sets the initial time value.
		/// The timer has to be initialized for this.
		/// </summary>
		public void Start() {
			//check to see if initialized
			if ( !fInitialized ) {
				throw new Exception("Cannot start. Timer not initialized");
			}

			//initialize time value
			QueryPerformanceCounter(ref fLastTime);
		}

		/// <summary>
		/// Gets the elapsed milliseconds since the last call to this method
		/// </summary>
		/// <returns>the elapsed milliseconds</returns>
		public double GetElapsedMilliseconds() {
			//make sure the timer is initialized
			if ( !fInitialized ) {
				throw new Exception("Cannot get elapsed milliseconds. Timer not initialized");
			}

			//get current number of ticks
			QueryPerformanceCounter(ref fCurrentTime);

			//calculate number of milliseconds since last call
			fElapsedMilliseconds = ((double)(fCurrentTime - fLastTime) / (double)(fTicksPerSecond)) * 1000;

			//store current time for next call
			fLastTime = fCurrentTime;

			//return milliseconds
			return fElapsedMilliseconds;
		}

		/// <summary>
		/// Gets the elapsed seconds since the last call to this method
		/// </summary>
		/// <returns>the elapsed seconds</returns>
		public double GetElapsedSeconds() {
			//make sure the timer is initialized
			if ( !fInitialized ) {
				throw new Exception("Cannot get elapsed seconds. Timer not initialized");
			}

			//get current number of ticks (time)
			QueryPerformanceCounter(ref fCurrentTime);

			//calculate number of seconds since last call
			fElapsedSeconds = ((double)(fCurrentTime - fLastTime) / (double)(fTicksPerSecond));

			//store current time for next call
			fLastTime = fCurrentTime;

			//return milliseconds
			return fElapsedSeconds;
		}

		#endregion
	}
}
