[![Stories in Ready](https://badge.waffle.io/scopetech/scope-sandbox.png?label=ready&title=Ready)](https://waffle.io/scopetech/scope-sandbox)
Labels
=============

Labels classify items by:

 1. Reason of creation of an issue
     1. **bug** - issue creator found a bug in software and asks for code modifications to fix it
     2. **feature** - issue creator asks for code modifications to implemet functionality
     3. **query** - issue creator asks for some actions related to development or testing process but do not require code modifications
     4. **question** - issue creator asks a question, question should be answered within an issue
     5. **documentation** - issue creator requests documentation
 2. Severity, if issue is showstopper for further testing, or significant part of functionality is not working, then mark this issue with **critical**
 3. Relation to other issues, i.e. **duplicate** - issue with same/similar request or description already exists. Number of duplicated issue should be added to comments.
 4. Specific developer skills required to complete issue, e.g.: **iOS** or **android**, items marked with these labels must be picked up by developers who has appropriate skills.
 5. Issue state
     1. **verified** - closed issue is verified by issue creator (issues that created by Scope developers, should be verified by Scope testers)
     2. **waiting** - developers asked testers for requirements, additional information or approval, testers must provide additional information
     3. **low-context** is a label used to indicate that insufficient information was supplied for the developers to understand or diagnose the issue. Developer even can't formulate a question to issue creator. Additional information is needed by the creator/author of the issue.
     4. **rejected** - things which will not be done or cancelled
 6. By review result, i.e. implementation of issues marked with **refactor** requires refactoring, what exactly must be refactored, must be mentioned in issue comments.  
 7. The rest of labels are customer companies or specific functionality part labels. These labels are informational and can be used for prioritization or for targeting issues to particular developer or developer group who dedicated to specific  label.  

Active development stages
==========================

Active development stage is Milestone. Milestone has development start and planned development end date, between these dates Milestone is active. Multiple milestones can be active at the point of time, but team have to try to keep only one active milestone at the point of time. Features have to be included into milestone before implementation.   

Pipelines 
===================

 1. **New** - All newly created issues automatically appear there. If you do not know how and when issue should be processed, just leave issue in **New** pipeline
 2. **Backlog** - everything that could be implemented to improve product, but not yet planned.
 3. **Waiting & Analyzing** - Item have to be implemented within active development stages but it is not analyzed enough
 4. **Short List** - Item is analyzed and detailed enough, developers should pick it within active development stages
 5. **In Progress** - Developer is implementing, fixing or refactoring item right now, all items in this list must have assigned person. Only one "In Progress" item must be assigned to each developer at a time, exceptions to this rule are acceptable but require reasonable motivation. When developer completes work on issue, developer moves issue to **Review** or **Closed** pipeline depending on team agreement for active development stages.
 6. **Review** - There are 2 ways how issues arrive to **Review**  pipeline:
     1. Team has agreement to move completed development tasks to **Review** pipeline. These issues must be picked by Team Lead or person delegated by Team Lead to check compliance of developed code to common architecture.
     2. Closed issue is reopened. Depending on development stage, issue labels, issue content and reopening reason, these issues is picked by developers to process or by Team Lead to analyze.
 7. **Closed** - Only closed issues are stored there. Closed means development complete. Tester can test issues in **Closed** pipeline and mark them with **verified** label when issue is tested successfully. Closed issue can be reopened if not implemented.
 

 

