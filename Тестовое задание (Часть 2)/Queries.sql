SELECT Cl."ClientName", COUNT(ClCont."Id")
FROM "Clients" Cl
LEFT JOIN "ClientContacts" ClCont
ON ClCont."ClientId" = Cl."Id"
GROUP BY Cl."Id"

SELECT Cl."ClientName"
FROM "Clients" Cl
INNER JOIN "ClientContacts" ClCont
ON ClCont."ClientId" = Cl."Id"
GROUP BY Cl."Id"
HAVING COUNT(1) > 2