Labels
=============

Labels classify items by:

 1. Reason of creation of an issue
     1. **bug** - issue creator found a bug in software and asks for code modications to fix it
     2. **feature** - issue creator asks for code modications to implemet functionality
     3. **query** - issue creator asks for some actions related to development or testing process but do not require code modifications
     4. **question** - issue creator asks a quetion, question should be answered within an issue
     5. **documentation** - issue creator requests documentation
 2. Severity, if issue is showstopper for further testing, or significant part of functionality is not working, then mark this issue with **critical**
 3. Relation to other issues, i.e. **duplicate** - issue with same/similar request or description already exists. Number of duplicated issue shoulld be added to comments.
 4. Issue state
     1. **verified** - closed issue is verified by issue creator (issues that created by Scope developers, should be verified by Scope testers)
     2. **waiting** - developers asked testers for requirements, additional information or approval, testers must provide additional information
     3. **low-context** is a label used to indicate that insufficient information was supplied for the developers to understand or diagnose the issue. Additional information is needed by the creator/author of the issue.
     4. **rejected** - things which will not be done or cancelled


