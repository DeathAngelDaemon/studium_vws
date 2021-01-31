% set up the facts
parent_child(ecthelion, denethor).
parent_child(adrahil, finduilas).
parent_child(thengel, theodwyn).
parent_child(thengel, theoden).
parent_child(morwen, theodwyn).
parent_child(morwen, theoden).
parent_child(denethor, boromir).
parent_child(finduilas, boromir).
parent_child(denethor, faramir).
parent_child(finduilas, faramir).
parent_child(eomund, eowyn).
parent_child(eomund, eomer).
parent_child(theodwyn, eowyn).
parent_child(theodwyn, eomer).
parent_child(theoden, theodred).
parent_child(elfhild, theodred).
parent_child(faramir, elboron).
parent_child(eowyn, elboron).
parent_child(eomer, elfwein).
parent_child(lothiriel, elfwein).
parent_child(elboron, barahir).

% looking for siblings
siblings(X,Y) :-
  parent_child(Parent,X),
  parent_child(Parent,Y),
  X \= Y.

% looking for uncle/aunt
uncle_aunt(X,Y) :-
  siblings(X,Somebody),
  parent_child(Somebody,Y).

% looking for cousin
cousin(X,Y) :-
  uncle_aunt(Somebody,X),
  parent_child(Somebody,Y).

% check being ancestor
ancestor(X,Y) :- parent_child(X,Y).
ancestor(X,Y) :- 
  parent_child(X,Somebody),
  ancestor(Somebody,Y).

% check being descendent
descendent(X,Y) :- ancestor(Y,X).

% output a list of all descendents
descendent_list(Ancestor) :-
  findall(Person, descendent(Person,Ancestor), List),
  write(List).

% example usages
% ?- ancestor(denethor, elboron).
% ?- descendent(elboron, denethor).
% ?- descendent_list(denethor).
% ?- descendent_list(thengel).
% ?- siblings(boromir, faramir).
% ?- cousin(elboron, elfwein).