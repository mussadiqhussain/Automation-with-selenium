describe("",() =>
{
    beforeEach(() =>{
        cy.visit("/")
    })
    it.only("Basic form",()=>{
        cy.contains('Forms').click()
        cy.contains('Form Layouts').click()
        cy.get('#exampleInputEmail1').type('talhadon@mil.com')
        cy.get('#exampleInputPassword1').type('talha')
        cy.contains('nb-card','Basic form').find('.custom-checkbox').click()

        cy.contains('nb-card','Basic form').find('[class="appearance-filled size-medium status-danger shape-rectangle transitions"]').click()
        cy.url().should('equal','http://localhost:4200/pages/forms/layouts')
        // cy.fixture('testdata.json').its(1).as('basicform')
        // cy.get('@basicform').then( user=>{
        //     cy.get("#exampleInputEmail1").type(user.email)
        //     cy.get("#exampleInputPassword1").type(user.password)
        // })
        // cy.contains('nb-card','Basic form').find('.custom-checkbox').click()
        // cy.contains('nb-card','Basic form').find('[class="appearance-filled size-medium status-danger shape-rectangle transitions"]').click()
        // cy.url().should('equal','http://localhost:4200/pages/forms/layouts')
    })
    it("Using the Grid",() =>{
        cy.contains("Forms").click() 
        cy.contains("Form Layouts").click()  
        cy.fixture('testdata.json').its(0).as('user')
        cy.get('@user').then( user =>{
        cy.get("#inputEmail1").type(user.email)  
        cy.get("#inputPassword2").type(user.password)
        }

        )
        // cy.get("#inputEmail1")   
        // cy.get("#inputPassword2")  
        cy.contains('nb-card','Using the Grid').find('[type="radio"]').eq('0').should('not.be.checked')
        cy.contains('nb-card','Using the Grid').find('[type="radio"]').eq('0').click({force:true})
        cy.contains('nb-card','Using the Grid').find('[type="radio"]').eq('0').should('be.checked')
        cy.contains('nb-card','Using the Grid').find('[type="radio"]').eq('1').should('not.be.checked')
        cy.contains('nb-card','Using the Grid').find('[type="radio"]').eq('1').click({force:true}).should('be.checked')
        cy.contains('nb-card','Using the Grid').find('[type="radio"]').eq('0').should('not.be.checked')
        cy.contains('nb-card','Using the Grid').find('[type="radio"]').eq('2').should('be.visible').should('be.disabled')
        cy.contains('nb-card','Using the Grid').find('[type="submit"]')
    })
    it("Horizontal form", ()=>{
        cy.contains("Forms").click() 
        cy.contains("Form Layouts").click() 
        cy.get("#inputEmail3")
        cy.get("#inputPassword3")
        cy.contains('nb-card','Horizontal form').find('[class="text"]')
        cy.contains('nb-card','Horizontal form').find('[class="appearance-filled size-medium status-warning shape-rectangle transitions"]')
        
    })
    it("Form without labels", ()=>{
        cy.contains("Forms").click() 
        cy.contains("Form Layouts").click() 
        cy.contains('nb-card','Form without labels').find('[placeholder="Recipients"]')
        cy.contains('nb-card','Form without labels').find('[placeholder="Subject"]')
        cy.contains('nb-card','Form without labels').find('[placeholder="Message"]')
        cy.contains('nb-card','Form without labels').find('[status="success"]')
    })
}
)