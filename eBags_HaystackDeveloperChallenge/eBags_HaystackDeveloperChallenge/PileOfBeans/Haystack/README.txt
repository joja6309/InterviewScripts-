BACKGROUND

The idea is that we have a pile of straw (the haystack).
Each piece of straw has color and length values associated to it.
Our goal is to organize the pile of straw into groups of color, ordered by their length.
We also would like any duplicate pieces of straw removed from the groups.


REQUIREMENTS

1) MUST create an implementation of the [IHaystackOrganizer] interface.
2) MUST demonstrate the execution of your [IHaystackOrganizer] implementation with a Unit Test.
3) MUST sort the [Haystack] "pile" of [Straw] into their associated color-groups on the [SortByColorResult] object
	A) MUST classify [Straw] instance as "reds" when the "ColorRed" value is greater than both the "ColorGreen" and "ColorBlue" values
	B) MUST classify [Straw] instance as "greens" when the "ColorGreen" value is greater than both the "ColorRed" and "ColorBlue" values
	C) MUST classify [Straw] instance as "blues" when the "ColorBlue" value is greater than both the "ColorRed" and "ColorGreen" values
	D) MUST classify [Straw] instance as "grays" when the "ColorRed", "ColorGreen" and "ColorBlue" values are the same
	E) When two of the color values are the same but both are greater than the third, MUST classify [Straw] instance
		as one of the two color values that are the same (your call which bucket to group the instance under)
		i) HINT: Example: "red=200", "green=200", "blue=100", straw is neither "red-dominant" nor "green-dominant"
			so we must choose to default it to either the "red" or "green" bucket.
		ii) OPTIONAL bonus points for enhancing the [SortByColorResult] to allow for more than just "reds", "greens", "blues" and "grays"
			a) Potentially detect ranges of color values for "yellows", "cyans", "magentas", etc.
4) MUST order each list of [Straw] on the [SortByColorResult] object by the [Straw] object's "LengthInCm" value
	A) SHOULD be ordered from smallest to largest
5) MUST remove any [Straw] instances that are considered to be a duplicate
	A) Same "ColorRed", "ColorGreen", "ColorBlue" and "LengthInCm" values as an instance that has already been sorted.
6) SHOULD make the [IHaystackOrganizer] as efficient as possible
	A) Bonus points for extending the [SortByColorResult] to include the time it took to achieve the results.


DELIVERABLES/NOTES

1) Write the logic within the solution provided.
2) When you are finished, zip your solution back up and send it in.
3) Try to meet as many of the requirements as possible.
4) Time box your solution to around an 2 hours.
5) Cleverness, creativity and imagination are always a plus.
6) We want to see your development and problem solving skills.
7) Remember, there are many ways to craft this solution.
8) Show us what you can do.


HELP/TROUBLESHOOTING

-) Feel free to email us with any questions you may have.
-) Application is throwing an [OutOfMemoryException]:
	Try making the "PILE_SIZE_MIN" and "PILE_SIZE_MAX" values smaller within the [Haystack] object