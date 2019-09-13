---
title: Squire
---
## Summary

Squire is a project meant to allow students to drill the syntax of C#
and help with retention of that syntax.  This is accomplished by using MSTest
tests which evaluate the answers to the drill automatically, allowing a student
to receive feedback without the direct involvement of an instructor.

### How to use as a Student

Clone this repository locally, open the project in Visual Studio, then open your
first drill (we recommend `StringKihon`).  Attempt to fill in all of the methods
with correct answers, then run all of the Unit Tests (`Ctrl-R-A` by default).
Any Unit Test which does not pass indicates you have an incorrect answer which
you should revisit.

### How to use as an Instructor

We recommend using these drills to supplement actual classroom education.  We
generally will time box any given run of these drills (we use 30 minutes) at the
end of which you should review all of the correct answers with the student.

If you reach the point of needing to know the correct answer and your instructor
is not available, then this page contains solutions to all of the Kihons below.

### What is a Kihon?

Kihon is a term borrowed from the Martial Arts, just as Kata is also borrowed.
[Wikipedia defines it as follows](https://en.wikipedia.org/wiki/Kihon):

> Kihon (基本, きほん) is a Japanese term meaning "basics" or "fundamentals." The term is used to refer to the basic techniques that are taught and practiced as the foundation of most Japanese martial arts. Kihon in martial arts can be seen as analogous to basic skills in, for example, basketball.

These drills are meant to reinforce the fundamentals, they are not a complex form
meant to recreate real world scenarios (the rough definition of Kata) but instead
are the foundational skills.

## Solutions
<ul>
  {% for post in site.posts %}
    <li>
      <a href="{{ post.url | relative_url }}">{{ post.title }}</a>
    </li>
  {% endfor %}
</ul>

## License

<a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/">
  <img alt="Creative Commons License" style="border-width:0" src="https://i.creativecommons.org/l/by-nc-sa/4.0/88x31.png" />
</a>
<br />
This work is licensed under a
<a rel="license" href="http://creativecommons.org/licenses/by-nc-sa/4.0/">Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License</a>.
