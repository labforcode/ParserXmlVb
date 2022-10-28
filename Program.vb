Imports System
Imports System.Xml.Serialization

Module Program
    Sub Main(args As String())

        Dim strXml As String = "<?xml version=""1.0"" encoding=""utf-8""?><wsRastreamento><rst versao=""1.0"" ><rstStatus stsCd=""1"">RASTREAMENTO CONCLUIDO COM SUCESSO</rstStatus><emi><rem remCnpj=""57460644000180"">DGI IMPORTACAO E EXPORTACAO LTDA.</rem><emiTransp transpCnpj=""82110818000121"">ALFA TRANSPORTES EIRELI</emiTransp><emiUnid>GUARULHOS</emiUnid></emi><NF nro=""824082""><NFCtrc>8026604</NFCtrc><NFData>20-10-2022</NFData><NFDest>LAIS PAPEL DE OLIVEIRA  EPP</NFDest><NFInicio>GUARULHOS</NFInicio><NFFim>BEBEDOURO</NFFim><NFCidade>BEBEDOURO-SP</NFCidade></NF><embarque><embNF><embOrigem>GUARULHOS</embOrigem><embDestino>RIBEIRAO PRETO</embDestino><embSaida>24-10-2022 -- 20:52</embSaida><embChegada>25-10-2022 -- 04:21</embChegada></embNF></embarque><entrega><entS><entSaida>25-10-2022 -- 16:46</entSaida></entS><entNF><entData>28-10-2022</entData><entHora>18:31</entHora><entNome>Leonardo</entNome><entSetor></entSetor><entComprovante>https://areadocliente.alfatransportes.com.br/comprovante.php?cte=10/8026604</entComprovante></entNF></entrega></rst></wsRastreamento>"



        Dim xDoc = XDocument.Parse(strXml)
        Dim xElement = xDoc.Element("wsRastreamento")


        Dim wsRastreamento = New WsRastreamento()
        wsRastreamento.LerWsRastreamento(xElement)


    End Sub

    Public Class WsRastreamento
        Private rst As Rst

        Public Sub New()
            rst = New Rst()
        End Sub

        Public Sub LerWsRastreamento(xElement As XElement)

            Dim rstElemtn = xElement.Element("rst")
            rst.LerRst(rstElemtn)

        End Sub

    End Class

    Public Class Rst
        Private rstStatus As String
        Private embarque As Embarque
        Private entrega As Entrega

        Public Sub New()
            embarque = New Embarque
            entrega = New Entrega
        End Sub

        Public Sub LerRst(xElement As XElement)

            rstStatus = xElement.Element("rstStatus").Value.ToString
            embarque.LerEmbarque(xElement)
            entrega.LerEntrega(xElement)

        End Sub

    End Class


    Public Class Embarque
        Private embNF As EmbNF

        Public Sub New()
            embNF = New EmbNF
        End Sub

        Public Sub LerEmbarque(xElement As XElement)
            Dim childNode = xElement.Element("embarque")
            embNF.LerEmbNF(childNode)
        End Sub

    End Class

    Public Class EmbNF
        Private embOrigem As String
        Private embDestino As String
        Private embSaida As String
        Private embChegada As String

        Public Sub LerEmbNF(xElement As XElement)
            Dim childNode = xElement.Element("embNF")
            embOrigem = childNode.Element("embOrigem").Value.ToString
            embDestino = childNode.Element("embDestino").Value.ToString
            embSaida = childNode.Element("embSaida").Value.ToString
            embChegada = childNode.Element("embChegada").Value.ToString
        End Sub

    End Class

    Public Class Entrega
        Private entS As EntS
        Private entNF As EntNF

        Public Sub New()
            entS = New EntS
            entNF = New EntNF
        End Sub

        Public Sub LerEntrega(xElement As XElement)
            Dim childNode = xElement.Element("entrega")
            entS.LerEntS(childNode)
            entNF.LerEntNf(childNode)

        End Sub

    End Class

    Public Class EntS
        Private entSaida As String

        Public Sub LerEntS(xElement As XElement)
            Dim childNode = xElement.Element("entS")
            entSaida = childNode.Element("entSaida").Value.ToString
        End Sub

    End Class

    Public Class EntNF
        Private entData As String
        Private entHora As String
        Private entNome As String
        Private entSetor As String
        Private entComprovante As String


        Public Sub LerEntNf(xElement As XElement)
            Dim childNode = xElement.Element("entNF")
            entData = childNode.Element("entData").Value.ToString
            entHora = childNode.Element("entHora").Value.ToString
            entNome = childNode.Element("entNome").Value.ToString
            entSetor = childNode.Element("entSetor").Value.ToString
            entComprovante = childNode.Element("entComprovante").Value.ToString
        End Sub

    End Class
End Module



