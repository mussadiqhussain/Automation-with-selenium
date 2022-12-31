describe("",() =>
{
    beforeEach(() =>{
        cy.visit("/")
    })
    it("Basic form",()=>{
        cy.contains('Forms').click()
        cy.contains('Form Layouts').click()
        cy.fixture('testdata.json').its(1).as('basicform')
        cy.get('@basicform').then( user=>{
            cy.get("#exampleInputEmail1").type(user.email)
            cy.get("#exampleInputPassword1").type(user.password)
        })
        cy.contains('nb-card','Basic form').find('.custom-checkbox').click()
        cy.contains('nb-card','Basic form').find('[class="appearance-filled size-medium status-danger shape-rectangle transitions"]').click()
        cy.url().should('equal','http://localhost:4200/pages/forms/layouts')
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
    it("invoke",()=>{
        cy.contains("Forms").click()
        cy.contains("Form Layouts").click()
        cy.get("[for='exampleInputEmail1']").should('contain','Email address')
        cy.get("[for='exampleInputEmail1']").then(talha =>{
            expect(talha.text()).to.equal('Email address')
        } )
        cy.get("[for='exampleInputEmail1']").invoke('text').then(text=>{
            expect(text).to.equal('Email address')
        })
        cy.contains('nb-card','Basic form')
        .find('nb-checkbox').
        click()
        .find('.custom-checkbox')
        .invoke('attr','class')
        // .should('contain','checked')
        .then(ClassVvalue=>{
            expect(ClassVvalue).to.contain('checked')
        })
    }
    )
    it("assert property", ()=> {

        cy.contains('Forms').click()
        cy.contains('Datepicker').click()
        cy.contains('nb-card', 'Common Datepicker').find('input').then(input =>{
        cy.wrap(input).click()
        cy.get('nb-calendar-day-picker').contains('12').click()
        cy.wrap(input).invoke('prop', 'value').should('contain', 'Dec 12, 2022')


        })
    })
    it("Using the Grid validation",() =>{
        cy.contains("Forms").click() 
        cy.contains("Form Layouts").click()  
        cy.fixture('testdata.json').its(0).as('user')
        cy.get('@user').then( user =>{
        cy.get("#inputEmail1").type(user.email)  
        cy.get("#inputPassword2").type(user.password)
        })
        // cy.get("#inputEmail1")   
        // cy.get("#inputPassword2")  
        cy.contains('nb-card','Using the Grid').find('[type="radio"]').eq('0').should('not.be.checked')
        cy.contains('nb-card','Using the Grid').find('[type="radio"]').eq('0').click({force:true})
        cy.contains('nb-card','Using the Grid').find('[type="radio"]').eq('0').should('be.checked')
        cy.contains('nb-card','Using the Grid').find('[type="radio"]').eq('1').should('not.be.checked')
        cy.contains('nb-card','Using the Grid').find('[type="submit"]').click()
        cy.contains('nb-card','Using the Grid')
        .find('#inputEmail1')
        .invoke('prop','validationMessage')
        .then(error=>{
                expect(error).to.contain("Please include an '@' in the email address. 'generiemailcypress.io' is missing an '@'.")
            })
            
            
        })
        it.only("inline form",()=>{
        cy.contains("Forms").click() 
        cy.contains("Form Layouts").click()  
        cy.contains('nb-card','Inline form').find('[placeholder="Jane Doe"]')
        cy.contains('nb-card','Inline form').find('[placeholder="Email"]')
        cy.contains('nb-card','Inline form').find('[class="text"]')
        cy.contains('nb-card','Inline form').find('[type="submit"]')
        
        
        })
        
    })