using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Coding Exercise – Software Developer
//This exercise consists of two parts: design and implementation.It is designed to take a few hours, but there is no hard time limit – please do not feel rushed.Also, questions are welcome, so feel free to ask.
//Design
//Provide a class design for an N-way, set-associative cache.
//Design requirements:
// The cache itself is entirely in memory (i.e.it does not communicate with a backing store or use any I/O)

// The client interface should be type-safe for keys and values and allow for both the keys and values to be of an arbitrary
//type(e.g., strings, integers, classes, etc.). For a given instance of a cache all keys will be the same type and all 
//values will be the same type.

// Design the interface as a library to be distributed by clients.
//Assume that the client doesn’t have source code to your library and that internal data structures aren’t exposed to the client.

// The design should allow for any replacement algorithm to be implemented by the client.
//Please provide the LRU and MRU algorithms as part of your solution.

// Example use case: As an in-memory cache on an application server, storing data associated with user id, in order to avoid a database dip for every request.
//Submit the design as a PDF.
//Implementation
//Impleme

//nt the above design.C# is preferred, but if you are unfamiliar with C#, Java or Python may be used.
//Implementation requirements:
// Prioritize correctness, robustness, and extensibility over extra features and optimizations.
// Write your code with the quality bar you would use for production code.
//Submit your response as a.zip of a Visual Studio solution (if you’re not using C#, as a .zip of your sources with a readme on how to compile and run).
//IMPORTANT: Be sure to scrub your submission of any binaries or executable files(e.g. *.exe, *.dll, *.bat, etc.). Our email filter is very sensitive and may silently delete emails with archive attachments containing these file types.

namespace N_Way_Set_Associative_Cache
{
    public class Cache
    {
        private int cache_size {
            get; set; }
        private int cache_associativity {
            get; set; } 
        


        Cache(int items_per_cache, int number_of_caches)
            {

            }


    }
}
