var url = '/appeal';

var app = new Vue({
    el: '#app',
    data: {
        search: "",
        editing: false,
        loading: false,
        objectIndex: 0,
        appealModel: {
            id: 0,
            country: 0,
            region: "",
            city: "",
            phone: "",
            reason: "",
            department: 0
        },
        appeals: []
    },
    mounted() {
        this.getAppeals();
    },
    computed: {
        filteredAppeals() {
            return this.appeals.filter(appeal => {
                return appeal.country.indexOf(this.search) > -1 ||
                    appeal.region.indexOf(this.search) > -1 ||
                    appeal.city.indexOf(this.search) > -1 ||
                    appeal.phone.indexOf(this.search) > -1 ||
                    appeal.reason.indexOf(this.search) > -1 ||
                    appeal.department.indexOf(this.search) > -1;
            });
        }
    },
    methods: {
        getAppeal(id) {
            this.loading = true;
            axios.get(url + '/' + id)
                .then(res => {
                    console.log(res);
                    var appeal = res.data;
                    this.appealModel = {
                        id: appeal.id,
                        country: appeal.country,
                        region: appeal.region,
                        city: appeal.city,
                        phone: appeal.phone,
                        reason: appeal.reason,
                        department: appeal.department
                    }
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                })
        },
        getAppeals() {
            this.loading = true;
            axios.get(url)
                .then(res => {
                    console.log(res);
                    this.appeals = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        createAppeal() {
            this.loading = true;
            axios.post(url, this.appealModel)
                .then(res => {
                    console.log(res.data);
                    this.appeals.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.resetForm();
                });
        },
        deleteAppeal(id, index) {
            this.loading = true;
            axios.delete(url + '/' + id)
                .then(res => {
                    console.log(res);
                    this.appeals.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        updateAppeal() {
            this.loading = true;
            axios.put(url, this.appealModel)
                .then(res => {
                    console.log(res.data);
                    this.appeals.splice(this.objectIndex, 1, res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.resetForm();
                });
        },
        newAppeal() {
            this.editing = true;
            this.appealModel.id = 0;
        },
        editAppeal(id, index) {
            this.objectIndex = index;
            this.getAppeal(id);
            this.editing = true;
        },
        cancel() {
            this.editing = false;
        },
        resetForm() {
            this.loading = false;
            this.editing = false;
            window.location.reload();
        }
    }
});
Vue.config.devtools = true;